import os

urun_card = "Views/Shared/Partials/Site/_UrunCard.cshtml"
with open(urun_card, "r") as f:
    content = f.read()

# Fix the broken quote and remove hardcoded discount badge (optional, let's keep it but fix the quote)
content = content.replace('asp-route-id="@Model.Id""', 'asp-route-id="@Model.Id"')

# Format price
content = content.replace('@Model.fiyat ₺', '@Model.fiyat.ToString("C")')

with open(urun_card, "w") as f:
    f.write(content)

details_card = "Views/Urun/Details.cshtml"
with open(details_card, "r") as f:
    content = f.read()

# Format price
content = content.replace('@Model.fiyat ₺', '@Model.fiyat.ToString("C")')
content = content.replace('@item.fiyat ₺', '@item.fiyat.ToString("C")')

# Remove hardcoded thumbs
thumbs_start = content.find('<div class="thumbs-wrap">')
thumbs_end = content.find('</div>', thumbs_start) + 6
if thumbs_start != -1:
    content = content[:thumbs_start] + "<!-- TODO: Dinamik çoklu resimler (Galeri) buraya gelecek -->" + content[thumbs_end:]

# Fix Benzer urunler sepete ekle button (from <a> to <form>)
old_btn = '<a href="#" class="btn btn-light w-100">\n                                        <i class="fa fa-shopping-basket me-1"></i> Sepete Ekle\n                                    </a>'
new_btn = '''<form action="/Cart/AddToCart" method="post" class="w-100">
                                        <input type="hidden" name="urunId" value="@item.Id" />
                                        <button type="submit" class="btn btn-light w-100">
                                            <i class="fa fa-shopping-basket me-1"></i> Sepete Ekle
                                        </button>
                                    </form>'''
content = content.replace(old_btn, new_btn)

with open(details_card, "w") as f:
    f.write(content)

print("UI patches applied.")
