import os

directory = "Views"

for root, _, files in os.walk(directory):
    for file in files:
        if file.endswith(".cshtml"):
            filepath = os.path.join(root, file)
            with open(filepath, "r") as f:
                content = f.read()

            if 'class="text-white text-decoration-none"' in content:
                content = content.replace('class="text-white text-decoration-none"', 'class="text-primary text-decoration-none"')
                with open(filepath, "w") as f:
                    f.write(content)
                print(f"Fixed breadcrumb color in {filepath}")
