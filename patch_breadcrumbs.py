import os

directory = "Views"

for root, _, files in os.walk(directory):
    for file in files:
        if file.endswith(".cshtml"):
            filepath = os.path.join(root, file)
            with open(filepath, "r") as f:
                content = f.read()

            if '<a href="#">Anasayfa</a>' in content:
                content = content.replace('<a href="#">Anasayfa</a>', '<a href="/" class="text-white text-decoration-none">Anasayfa</a>')
                with open(filepath, "w") as f:
                    f.write(content)
                print(f"Patched breadcrumb in {filepath}")
