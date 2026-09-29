import os
import re

directory = "Controllers"

for root, _, files in os.walk(directory):
    for file in files:
        if file.endswith("Controller.cs"):
            filepath = os.path.join(root, file)
            with open(filepath, "r") as f:
                content = f.read()

            # Find [HttpPost] and add [ValidateAntiForgeryToken] if not present
            # We look for [HttpPost] on a line, and if the next line or same block doesn't have ValidateAntiForgeryToken, we add it.
            # A simpler way: replace [HttpPost] with [HttpPost]\n    [ValidateAntiForgeryToken]
            # But only if ValidateAntiForgeryToken is not already in the file.
            
            if "[HttpPost]" in content and "[ValidateAntiForgeryToken]" not in content:
                content = content.replace("[HttpPost]", "[HttpPost]\n    [ValidateAntiForgeryToken]")
                with open(filepath, "w") as f:
                    f.write(content)
                print(f"Patched {file} for CSRF")
