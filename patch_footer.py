with open("Views/Shared/Partials/Site/_Footer.cshtml", "r") as f:
    content = f.read()

old_nav = """<nav class="text-center text-md-end">
                    <a href="#" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-facebook"></i>
                    </a>
                    <a href="#" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-instagram"></i>
                    </a>
                    <a href="#" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-youtube"></i>
                    </a>
                    <a href="#" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-twitter"></i>
                    </a>
                </nav>"""

new_nav = """<nav class="text-center text-md-end">
                    <a href="https://github.com/pedrorhan" target="_blank" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-github"></i>
                    </a>
                    <a href="https://www.linkedin.com/in/orhanefesacli/" target="_blank" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-linkedin"></i>
                    </a>
                    <a href="https://www.instagram.com/sclorhan/" target="_blank" class="btn btn-icon btn-outline-warning">
                        <i class="fab fa-instagram"></i>
                    </a>
                </nav>"""

content = content.replace(old_nav, new_nav)

with open("Views/Shared/Partials/Site/_Footer.cshtml", "w") as f:
    f.write(content)

print("Footer patched")
