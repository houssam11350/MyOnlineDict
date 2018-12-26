# MyOnlineDict
MyOnlineDict is a free open-source application that helps you to translate texts from clipboard with online dictionaries.

MyOnlineDict uses the following third-party software:
- **CefSharp**: Chromium embedded browser https://github.com/cefsharp/CefSharp

# FEATURES:
1. Watch clipboard to translate texts automatically.
2. Configurable: you can add your online dictionary by editing 'Dict file', 'Dict' menu -> 'Open Dict File'; then add the link of the dictionary by replacing the target word by '%WORD%'; for example Google translator uses the following url tró translate 'Dog' from English to Arabic: https://translate.google.com/#de/ar/dog then I copy this URL and replace 'dog' by %WORD%
	- 'Dict File' is actually 'mydicts.txt' has the following structure:
	   - #url@@@@@@@@title@@@@@@@@scrolldown=100@@@@@@@@scrollright=100@@@@@@@@zoomlevel=100
	   - **#** : this means comment; and MyOnlineDict will not load this dictionary in the main window.
	   - **url**: is the URL of the dictionary; you must replace the target word by %WORD%
	   - **title**: is the title of the dictionary; that displays on the main window.
	   - **scrolldown**: you make the dictionary scroll down after translation, to see the suitable part of the translation; make it 0 if you don't understand this.
	   - **scrollright**: you make the dictionary scroll right after translation, to see the suitable part of the translation; make it 0 if you don't understand this.
	   - **zoomlevel**: zooming the browser after translate; it should be from -80 to 300.
	   - **[right_click_dict]**: this part for the right click menu if the browser; you may want to translate text in the browser in specific translator; it has the following structure:
			- #url@@@@@@@@title@@@@@@@@fn 
			- **url**: s the URL of the dictionary; you must replace the target word by %WORD%
			- **title**: is the title of the dictionary.
			- **fn**: is the shortcut key to activate this option; it can be f1,f3,f4,f5,f6,f7,f8,f9,f10,f11,f12,no.
			- **#**: this means comment; and MyOnlineDict will not load this dictionary in the right click menu.
	   - After modifying the 'Dict File' go to 'Dict' menu -> 'Reload Dictionaries'

 
# DOWNLOAD:

- **MyOnlineDict_1.0.0.0**: https://github.com/houssam11350/MyOnlineDict/raw/master/Release/MyOnlineDict_1.0.0.0.zip

# SCREENSHOTS
![main window](https://raw.githubusercontent.com/houssam11350/MyOnlineDict/master/Screenshots/01.png)

# DEVELOPER:

- HOUSSAM ALSHAMI (houssam11350 aatt yahoo doott com).
