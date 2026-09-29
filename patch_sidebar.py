with open("Views/Shared/Partials/Site/_AccountSiderBar.cshtml", "r") as f:
    lines = f.readlines()

new_lines = []
skip = False
for line in lines:
    if "Adres" in line:
        skip = True
    if skip and "Bilgileri" in line:
        skip = False
        continue
    if not skip:
        new_lines.append(line)

with open("Views/Shared/Partials/Site/_AccountSiderBar.cshtml", "w") as f:
    f.writelines(new_lines)
