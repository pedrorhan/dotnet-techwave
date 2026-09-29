with open("Views/Shared/_SiteLayout.cshtml", "r") as f:
    content = f.read()

content = content.replace('<body class="bg-light">', '<body class="bg-light d-flex flex-column min-vh-100">')
content = content.replace('<main>', '<main class="flex-grow-1">')

with open("Views/Shared/_SiteLayout.cshtml", "w") as f:
    f.write(content)
