with open("Views/Shared/Partials/Site/_Topbar.cshtml", "r") as f:
    content = f.read()

content = content.replace('<div class="col-lg-5 col-sm-8 col-12 order-lg-last">', '<div class="col-lg-9 col-sm-8 col-12 order-lg-last ms-auto">')

with open("Views/Shared/Partials/Site/_Topbar.cshtml", "w") as f:
    f.write(content)
