with open("wwwroot/css/site.css", "r") as f:
    content = f.read()

# Replace the white breadcrumb colors with something darker or remove them
content = content.replace("color: #fff;", "color: var(--text-muted);")
content = content.replace("color: #fff !important;", "color: var(--text-muted) !important;")

with open("wwwroot/css/site.css", "w") as f:
    f.write(content)
