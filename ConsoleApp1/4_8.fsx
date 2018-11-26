open System
open System.Net
open System.Windows.Forms

let getWebsiteText uri =
    let websiteText = 
        let webClient = new WebClient()
        webClient.DownloadString(Uri uri)
    websiteText

let browser uri=
    new WebBrowser(ScriptErrorsSuppressed = true,
                    Dock = DockStyle.Fill,
                    DocumentText = getWebsiteText uri)

let form = new Form(Text = "Hello from F#")
form.Controls.Add (browser "http://heise.de")
form.Show()

