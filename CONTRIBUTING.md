# How to contribute

No code is perfect and we always welcome third-party patches. This document describes guidelines that we need contributors to follow so that we can accept their pull requests.

## Getting started

- Make sure you have an account on this site,
- Submit a ticket for your issue, assuming one does not already exists.
    - Write in English,
    - Use the imperative mood in the subject/title field,
    - Clearly describe the issue including steps to reproduce when it is a bug,
    - Make sure you fill in the earliest version that you know has the issue.
- Fork the repository on this site and `git-clone(1)` it locally.

## Making changes

- Create a topic branch from where you want to base your work,
- Make your changes taking [style guide](CODINGSTYLE.md) into account,
- Check for whitespace errors issuing `git diff --check`, `git diff --cached --check` or `git diff HEAD --check`,
- Make commits writing good [commit messages](http://chris.beams.io/posts/git-commit/),

## Submitting changes

- Push your changes to a topic branch in your fork of the repository,
- Submit a pull request to the project's repository,
- Update your ticket to mark you have submitted code and are ready for it to be reviewed. Include a link to the pull request in the ticket.


# GEDKeeper contributors

* **[Sergey Zhdanovskih](https://github.com/serg-norseman)**

  * Lead developer, maintainer

* **[Ruslan Garipov](https://github.com/ruslangaripov)**

  * English help contents
  * UDN format and sorter
  * Makefiles
  * Debugging and bug reports
  * Improvements of charts drawing and printing

* **[Igor Tyulyakov](https://github.com/g10101k)**

  * Debugging and bug reports
  * Improvement of UI features
  * Design solutions (MediaPlayer and portraits)

* **[Alexey Dokuchaev](https://github.com/danfe)**

  * FreeBSD port developed (https://www.freshports.org/misc/gedkeeper/)

* **[Kevin D. Sandal](https://github.com/Dreamer451)**

  * Proofreading of the English manual
  * Debugging and bug reports

* **[Milan Kosina](https://github.com/m-kosina)**

  * Debugging and bug reports
  * Development of new features

* **[Kevin Routley](https://github.com/fire-eggs)**

  * Debugging, bug reports and bug fixes
  * Development of some tests

* **[Alexander Curtis](https://github.com/alexandercurtis)**

  * Author of GEDmill (Family History Website Generator), now it is external plugin

* **[Alexander Zaytsev](https://github.com/hazzik)**

  * Improving the architecture and efficiency of the core
  * Testing and bug fixes
