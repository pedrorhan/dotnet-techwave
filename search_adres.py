import os

for root, _, files in os.walk("Views"):
    for file in files:
        if file.endswith(".cshtml"):
            path = os.path.join(root, file)
            with open(path, "r") as f:
                content = f.read()
            if "Adres Bilgileri" in content:
                print(f"Found in {path}")
