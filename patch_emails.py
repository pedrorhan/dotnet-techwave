import os

# 1. Update SeedDatabase.cs
with open("Data/SeedDatabase.cs", "r") as f:
    content = f.read()

content = content.replace('"orhaansacli@gmail.com"', '"admin@techwave.com"')
content = content.replace('"akinsacli12@gmail.com"', '"customer@techwave.com"')

with open("Data/SeedDatabase.cs", "w") as f:
    f.write(content)

# 2. Update README.md
with open("README.md", "r") as f:
    content = f.read()

content = content.replace('`orhaansacli@gmail.com`', '`admin@techwave.com`')
content = content.replace('`akinsacli12@gmail.com`', '`customer@techwave.com`')

with open("README.md", "w") as f:
    f.write(content)

print("Emails patched.")
