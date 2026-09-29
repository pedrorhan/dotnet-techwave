# 1. Update Cart Entity
with open("Data/Cart.cs", "r") as f:
    content = f.read()

update_method = """
    public void UpdateItem(int urunId, int miktar)
    {
        var item = CartItems.Where(i => i.UrunId == urunId).FirstOrDefault();
        if (item != null)
        {
            item.Miktar = miktar;
            if (item.Miktar <= 0)
            {
                CartItems.Remove(item);
            }
        }
    }
"""
if "UpdateItem" not in content:
    content = content.replace("public double AraToplam()", update_method + "    public double AraToplam()")
    with open("Data/Cart.cs", "w") as f:
        f.write(content)

# 2. Update ICartService & CartService
with open("Services/CartService.cs", "r") as f:
    content = f.read()

if "UpdateQuantity" not in content:
    content = content.replace("Task RemoveItem(int urunId, int miktar = 1);", "Task RemoveItem(int urunId, int miktar = 1);\n    Task UpdateQuantity(int urunId, int miktar);")
    
    update_service_method = """
    public async Task UpdateQuantity(int urunId, int miktar)
    {
        var cart = await GetCart(GetCustomerId());
        cart.UpdateItem(urunId, miktar);
        await _context.SaveChangesAsync();
    }
"""
    content = content.replace("public async Task RemoveItem(int urunId, int miktar = 1)", update_service_method + "    public async Task RemoveItem(int urunId, int miktar = 1)")
    with open("Services/CartService.cs", "w") as f:
        f.write(content)

# 3. Update CartController
with open("Controllers/CartController.cs", "r") as f:
    content = f.read()

if "UpdateQuantity" not in content:
    update_controller_method = """
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> UpdateQuantity(int urunId, int miktar)
    {
        await _cartService.UpdateQuantity(urunId, miktar);
        return RedirectToAction("Index", "Cart");
    }
"""
    content = content.replace("public async Task<ActionResult> RemoveItem(int urunId, int miktar)", update_controller_method + "    [HttpPost]\n    [ValidateAntiForgeryToken]\n    public async Task<ActionResult> RemoveItem(int urunId, int miktar)")
    with open("Controllers/CartController.cs", "w") as f:
        f.write(content)

# 4. Update Cart View
with open("Views/Cart/Index.cshtml", "r") as f:
    content = f.read()

old_input = '<input type="number" name="miktar" id="" value="@item.Miktar" class="form-control"\n                                            min="1">'
new_input = '''<form action="/Cart/UpdateQuantity" method="post">
                                            @Html.AntiForgeryToken()
                                            <input type="hidden" name="urunId" value="@item.UrunId">
                                            <input type="number" name="miktar" value="@item.Miktar" class="form-control" min="1" onchange="this.form.submit()">
                                        </form>'''
content = content.replace(old_input, new_input)
with open("Views/Cart/Index.cshtml", "w") as f:
    f.write(content)

print("Cart update functionality applied.")
