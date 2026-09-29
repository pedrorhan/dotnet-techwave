import os

files_to_patch = [
    "Models/Order/OrderCreateModel.cs",
    "Controllers/OrderController.cs",
    "Views/Order/Checkout.cshtml"
]

for filepath in files_to_patch:
    with open(filepath, "r") as f:
        content = f.read()
    
    content = content.replace("CartName", "CardName")
    content = content.replace("CartNumber", "CardNumber")
    content = content.replace("CartExpirationYear", "CardExpirationYear")
    content = content.replace("CartExpirationMonth", "CardExpirationMonth")
    content = content.replace("CartCVV", "CardCVV")
    
    with open(filepath, "w") as f:
        f.write(content)
    print(f"Patched typo in {filepath}")
