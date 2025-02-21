Option Explicit On
Imports SpeechLib
Imports System.Drawing.Imaging


Public Class Form1

    

    'Beschreibung Funktionen:
    '"Zeile" ist globale Variable für die jeweilige zeile die in die zieldatei oder den ziel string geschrieben werden soll
    'Saytext(x) liesst den gewählten string vor
    'zzei(x) = zufallszeile; wählt eine zufällige zeile aus datei x aus und schreibt diese in "Zeile"
    'zzah(x) = zufallszahl; erstellt eine zufallszahl zwischen 0 und zahl (integer) und schreibt diese in "Zeile"
    'zrang(x,y) = zufallsrange; erstellt eine zufallszahl zwischen zahl1 und zahl2 (integer) und schreibt diese in "Zeile"
    '-------------------
    'C:\Users\Spawn\Documents\Visual Studio 2010\Projects\Solarsystem Creator\Solarsystem Creator\data\vars\hyphenation.ini

    Public zeile As String = Nothing
    Public dummy As String = Nothing
    Public letzte As String = Nothing
    Public SAPI As Object = New SpeechLib.SpVoice
    Public systempartname As String = Nothing
    Public alles As String = Nothing

    'zuletzt genutzte strings
    Public sternzeit_name As String = Nothing
    Public sternzeit_digits_adder As String = Nothing
    Public jumpdrive_activated As String = Nothing
    Public test_string As String = Nothing
    Public sternzeit_digits As String = Nothing
    Public system_desc As String = Nothing
    Public system_parts As String = Nothing
    Public system_infos As String = Nothing
    Public planet_target_desc As String = Nothing
    Public planet_name_part As String = Nothing
    Public planet_target_info As String = Nothing
    Public planet_surface_structure_desc As String = Nothing
    Public planet_surface_structure As String = Nothing
    Public planet_surface_structure_adder As String = Nothing
    Public planet_surface_structure2 As String = Nothing
    Public planet_surface_scan_liquid As String = Nothing
    Public planet_surface_liquid As String = Nothing
    Public planet_surface_scan_liquid2 As String = Nothing
    Public planet_surface_temperature_desc As String = Nothing
    Public digits As String = Nothing
    Public planet_surface_temperature_adder As String = Nothing
    Public planet_surface_temperature_adder_end As String = Nothing
    Public cloud_desc As String = Nothing
    Public cloud_color As String = Nothing
    Public cloud_adder As String = Nothing
    Public cloud_color2 As String = Nothing
    Public cloud_adder_end As String = Nothing
    Public planet_surface_touchdown_scan As String = Nothing
    Public planet_surface_landing_desc As String = Nothing
    Public planet_surface_landing_desc2 As String = Nothing
    Public planet_surface_landing_desc3 As String = Nothing
    Public planet_surface_scan_env As String = Nothing
    Public planet_surface_scan_anti As String = Nothing
    Public planet_surface_scan_anti_found As String = Nothing
    Public life_alien_found As String = Nothing
    Public life_alien_color_desc As String = Nothing
    Public life_alien_color As String = Nothing
    Public life_alien_desc As String = Nothing
    Public life_alien_breast As String = Nothing
    Public life_alien_parts As String = Nothing
    Public life_alien_legs_desc As String = Nothing
    Public life_alien_legs_count As String = Nothing
    Public life_alien_legs As String = Nothing
    Public life_alien_arms_desc As String = Nothing
    Public life_alien_arms As String = Nothing
    Public life_alien_face_desc As String = Nothing
    Public life_alien_face As String = Nothing
    Public life_alien_face_desc2 As String = Nothing
    Public life_alien_mouth As String = Nothing
    Public life_alien_face_desc3 As String = Nothing
    Public life_alien_eyes As String = Nothing
    Public alien_behavior_desc As String = Nothing
    Public alien_behavior As String = Nothing
    Public alien_sidekick As String = Nothing
    Public alien_behavior_desc_add As String = Nothing
    Public alien_behavior2 As String = Nothing
    Public we_alien_handling As String = Nothing
    Public we_alien_handling2 As String = Nothing
    Public we_alien_handling3 As String = Nothing
    Public we_alien_handling4 As String = Nothing
    Public we_alien_handling5 As String = Nothing
    Public we_alien_handling6 As String = Nothing
    Public we_leaf_desc As String = Nothing
    Public ship_liftoff_desc As String = Nothing
    Public ship_liftoff_orbiting As String = Nothing
    Public ship_liftoff_doku As String = Nothing
    Public ship_liftoff_jumpready As String = Nothing
    Public start_jumpdrive As String = Nothing
    Public planet_surface_material As String = Nothing
    Public planet_surface_scan_material As String = Nothing
    Public life_possibility_desc As String = Nothing
    Public life_possibility As String = Nothing
    Public life_alien_size As String = Nothing
    Public life_alien_size_desc As String = Nothing
    Public life_alien_color_adder As String = Nothing
    Public system_desc_planetcount As String = Nothing
    Public system_desc_planets As String = Nothing
    Public system_desc_solcount As String = Nothing
    Public system_desc_solcount_intro As String = Nothing
    Public system_desc_solcount_adder As String = Nothing
    Public ichbinbreit As String = Nothing
    Public Rndm As New Random

    Private WithEvents Voice As SpVoice = Nothing


    Private Sub SayText(ByVal TextToSay As String) 'alte ausgabe warum auch immer aktuell in englisch
        If Voice Is Nothing Then Voice = New SpVoice
        Voice.Speak(TextToSay, SpeechVoiceSpeakFlags.SVSFlagsAsync)
    End Sub

    Private Sub saytext2(ByVal texttosay2 As String) 'neue ausgabe auf deutsch
        ' Dim SAPI As Object = New SpeechLib.SpVoice
        SAPI = CreateObject("SAPI.spvoice")
        SAPI.Voice = SAPI.GetVoices().Item(0)
        SAPI.Rate = TrackBar1.Value
        SAPI.Speak(texttosay2)
        'SAPI.WaitUntilDone = False
    End Sub

    Private Sub Voice_EndStream(StreamNumber As Integer, StreamPosition As Object) Handles Voice.EndStream
        Voice = Nothing
    End Sub

    Private Function NumberWord(number As Decimal) As String
        Dim listNum As New List(Of String)
        Dim einer = "? Ein Zwei Drei Vier Fünf Sechs Sieben Acht Neun".Split
        Dim zehner = "? Zehn Zwanzig Dreißig Vierzig Fünfzig Sechzig Siebzig Achzig Neunzig".Split
        Dim deci = "? Tausend Millionen Milliarden Billionen Billiarden Trillionen Trilliarden Quadrillionen Quadrilliarden".Split

        Dim tmpNr = number.ToString
        For i = tmpNr.Length To 0 Step -3
            Dim tmp = tmpNr.Substring(If(i < 3, 0, i - 3), If(i < 3, i, 3))
            If Not String.IsNullOrEmpty(tmp) Then listNum.Add(tmp)
        Next

        For i = 0 To listNum.Count - 1
            tmpNr = ""
            Dim n = listNum(i).PadLeft(3, "0"c)
            Dim h = n.Substring(0, 1)
            Dim e = If(n.Length - 1 > 1, n.Substring(2, 1), "0"c)
            Dim z = If(n.Length - 1 > 0, n.Substring(1, 1), "0"c)
            If h <> "0"c Then tmpNr = einer(CInt(h.ToString)) & "Hundert"
            If e <> "0"c Then tmpNr &= einer(CInt(e.ToString)) & "Und"
            If z <> "0"c Then tmpNr &= zehner(CInt(z.ToString))
            If String.IsNullOrEmpty(tmpNr) Then tmpNr = "?"c

            tmpNr = tmpNr.Replace("EinUndZehn", "Elf")
            tmpNr = tmpNr.Replace("ZweiUndZehn", "Zwölf")
            tmpNr = tmpNr.Replace("UndZehn", "Zehn")
            tmpNr = tmpNr.Replace("SechsZehn", "Sechzehn")
            tmpNr = tmpNr.Replace("SiebenZehn", "Siebzehn")
            If tmpNr.EndsWith("Und") Then tmpNr = tmpNr.Replace("Und", "")

            If i = 0 AndAlso tmpNr.EndsWith("Ein") Then tmpNr = tmpNr & "s"c

            If i = listNum.Count - 1 AndAlso listNum.Count - 1 > 1 AndAlso tmpNr.StartsWith("Ein") AndAlso Not tmpNr.Contains("Hundert") Then tmpNr = tmpNr.Insert(3, "e"c)
            listNum(i) = tmpNr
        Next

        tmpNr = ""
        For i = listNum.Count - 1 To 0 Step -1
            Dim tmp = If(listNum(i) = "?"c, "", listNum(i) & deci(i))

            If tmp.StartsWith("Eine") AndAlso tmp.EndsWith("nen") Then tmp = tmp.Substring(0, tmp.Length - 2)
            If tmp.StartsWith("Eine") AndAlso tmp.EndsWith("den") Then tmp = tmp.Substring(0, tmp.Length - 1)
            tmpNr &= tmp
        Next
        tmpNr = tmpNr.Replace("?"c, "")
        If String.IsNullOrEmpty(tmpNr) Then tmpNr = "Null"
        Return tmpNr
    End Function

    Private Function ISpVoice() As Object
        Throw New NotImplementedException
    End Function


    Public old As Integer = 6572
    Public Function Rand(ByVal min As Integer, ByVal max As Integer) As Integer 'ungenutzt
        Dim random As New Random(old + Date.Now.Millisecond)
        old = random.Next(min, max + CInt(IIf(Date.Now.Millisecond Mod 2 = 0, 1, 0)))
        Return old
    End Function

    Private Sub zzei(ByVal dateiname As String)
        Randomize()
        'text -> Encoding.Default() soll irgendwo hin wegen umlauten nur wo ?
        Dim lines() As String = System.IO.File.ReadAllLines(dateiname)
        ' Dim Rndm As New Random
        Dim Zufallszahl As Integer = Rndm.Next(0, lines.Length) '+ 1)
        '  Dim zufallszahl As Integer = Rand(0, lines.Length)
        zeile = lines(Zufallszahl).ToString
    End Sub

    Private Sub zzah(ByVal zahl As Integer)
        'Dim Rndm As New Random
        Dim Zufallszahl As Integer = Rndm.Next(0, zahl) '+ 1)
        zeile = Zufallszahl
    End Sub

    Private Sub zrang(ByVal zahl1 As Integer, zahl2 As Integer)
        ' Dim Rndm As New Random
        Dim Zufallszahl As Integer = Rndm.Next(zahl1, zahl2 + 1)
        zeile = Zufallszahl
    End Sub

    ' Private Sub gen_old(ByVal ini As String)
    'Dim silben As String = Nothing
    ' Dim Rndm As New Random
    '     Randomize()
    '     zzei(System.IO.Directory.GetCurrentDirectory.ToString + ini)
    '    silben = silben + zeile
    '    Threading.Thread.Sleep(Rndm.Next(0, 55)) 'wra auf 30
    '    dummy = dummy + silben
    '   If CheckBox2.Checked = True Then alles = alles + ini + vbNewLine
    '"public " + ini + " as string = nothing" + vbNewLine
    ' End Sub

  

    Function gen(ByVal ini As String) As String
        Dim silben As String = Nothing
        'Dim Rndm As New Random
        Randomize()
        zzei(System.IO.Directory.GetCurrentDirectory.ToString + ini)
        silben = silben + zeile
        Threading.Thread.Sleep(Rndm.Next(0, Date.Now.Millisecond / 3))
        dummy = dummy + silben
        If CheckBox2.Checked = True Then
            alles = alles + ini + vbNewLine
            alles = alles + zeile + vbNewLine + vbNewLine
        End If
        gen = zeile
    End Function

    Private Sub gensil(ByVal ini As String)
        Dim silben As String = Nothing
        ' Dim Rndm As New Random
        Randomize()
        zzei(System.IO.Directory.GetCurrentDirectory.ToString + ini)
        silben = silben + zeile
        Threading.Thread.Sleep(Rndm.Next(0, Date.Now.Millisecond / 3))
        dummy = dummy + silben

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

        'audio sources: http://www.mediacollege.com/downloads/sound-effects/star-trek/tos/
        'audio sources: http://www.trekcore.com/audio/

        ' If System.IO.File.Exists(Application.StartupPath + "data\sounds\background.wav") = True Then
        'My.Computer.Audio.Play(My.Resources.tng_bridge_1, AudioPlayMode.BackgroundLoop)


        'Zusatz Optionen: Sofern eine Datei welche genauso wie das Programm mit extension und dahinter .ini (text) oder .snd (.wav soundliste) oder .slo (.wav soundloopliste)
        'heist vorhanden ist wird das programm nicht angezeigt, dann wird daraus entweder eine zufällige zeile vorgelesen oder ein zufalls sound abgespielt.
        'anschliessend beendet sich das programm in dem fall selbst.
        '
        '.ini -> deutsche textliste
        '.ine -> englische textliste
        '.snd -> .wav soundliste
        '.slo -> .wav soundloopliste

        'falls er immer wider ins programm springt und nicht die liste abspielt wurde warscheinlich vergessen das der suffix .exe.[xyz] heissen muß!

        'text to read liste deutsch
        If System.IO.File.Exists((System.IO.Path.GetFileName(Application.ExecutablePath) + ".ini")) = True Then
            gen(("\" + System.IO.Path.GetFileName(Application.ExecutablePath) + ".ini"))
            TextBox1.Text = TextBox1.Text + dummy + vbNewLine
            dummy = Nothing
            textoptimize()
            saytext2(TextBox1.Text)
            End
        End If

        'text to read liste englisch
        If System.IO.File.Exists((System.IO.Path.GetFileName(Application.ExecutablePath) + ".ine")) = True Then
            gen(("\" + System.IO.Path.GetFileName(Application.ExecutablePath) + ".ine"))
            TextBox1.Text = TextBox1.Text + dummy + vbNewLine
            dummy = Nothing
            textoptimize()
            SayText(TextBox1.Text)
            End
        End If

        'einzel sound liste
        If System.IO.File.Exists((System.IO.Path.GetFileName(Application.ExecutablePath) + ".snd")) = True Then
            Dim snd As String = Nothing
            gen(("\" + System.IO.Path.GetFileName(Application.ExecutablePath) + ".snd"))
            My.Computer.Audio.Play((Trim(dummy)), AudioPlayMode.WaitToComplete)
            End
        End If

        'loop sound liste
        If System.IO.File.Exists((System.IO.Path.GetFileName(Application.ExecutablePath) + ".slo")) = True Then
            Dim snd As String = Nothing
            gen(("\" + System.IO.Path.GetFileName(Application.ExecutablePath) + ".slo"))
            My.Computer.Audio.Play((Trim(dummy)), AudioPlayMode.BackgroundLoop)
            Me.Width = 80
            Me.Height = 50
            Me.WindowState = FormWindowState.Minimized

        End If


    End Sub

    Private Sub textoptimize()

        dummy = TextBox1.Text 'umlaute convertieren - sollte ganz am ende kommen! die ini daten selbst dürfen KEINE umlaute beinhalten
        TextBox1.Text = dummy.Replace("ae", "ä")
        dummy = TextBox1.Text
        TextBox1.Text = dummy.Replace("ue", "ü")
        dummy = TextBox1.Text
        TextBox1.Text = dummy.Replace("oe", "ö")
        dummy = TextBox1.Text
        TextBox1.Text = dummy.Replace("Ae", "Ä")
        dummy = TextBox1.Text
        TextBox1.Text = dummy.Replace("Ue", "Ü")
        dummy = TextBox1.Text
        TextBox1.Text = dummy.Replace("Oe", "Ö")

        dummy = TextBox1.Text 'aussprache verbesserungen
        TextBox1.Text = dummy.Replace("Alien", "Äilien")

        TextBox1.Text = dummy.Replace(" ,", ",")
        TextBox1.Text = dummy.Replace("u e", "ue")
        TextBox1.Text = dummy.Replace("ein e", "eine")
        TextBox1.Text = dummy.Replace("ein en", "einen")

        dummy = Nothing

    End Sub

    Private Sub systemerreicht()
        system_desc = gen("\data\vars\system_desc.ini") 'systemankunft
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gensil("\data\vars\hyphenation.ini") 'systemnamen teile 4 stk
        'gensil("\data\vars\hyphenation.ini")
        systempartname = dummy                      'systemname zwischenspeichern für planeten ableitung
        dummy = dummy + " "
        ProgressBar1.Value = ProgressBar1.Value + 1

        gensil("\data\vars\hyphenation_pre.ini")
        gensil("\data\vars\hyphenation.ini")
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        system_parts = gen("\data\vars\system_parts.ini") 'systemnummerierung
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1



        'hier soll hin wieviele planeten es gibt, entfernungen und habitabele zone !!!

        

        system_desc_solcount_intro = gen("\data\vars\system_desc_solcount_intro.ini") 'sonnen einleitung                                
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        system_desc_solcount = gen("\data\vars\system_desc_solcount.ini") 'sonnen anzahl                                  
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        system_desc_solcount_adder = gen("\data\vars\system_desc_solcount_adder.ini") 'dazu gibt es                                
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        system_desc_planetcount = gen("\data\vars\system_desc_planetcount.ini") 'planetenanzahl                                 
        TextBox1.Text = TextBox1.Text + dummy + ", "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        system_desc_planets = gen("\data\vars\system_desc_planets.ini") 'systembeschreibung
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        '  system_desc_planets = gen("\data\vars\system_desc_planets_adder.ini") 'systembeschreibung
        ' TextBox1.Text = TextBox1.Text + dummy + " "
        '  dummy = Nothing
        '  ProgressBar1.Value = ProgressBar1.Value + 1

        ' system_desc_planets = gen("\data\vars\system_desc_planets.ini") 'systembeschreibung
        ' TextBox1.Text = TextBox1.Text + dummy + " "
        '  dummy = Nothing
        ' ProgressBar1.Value = ProgressBar1.Value + 1

        'was da los ist im system
        system_infos = gen("\data\vars\system_infos.ini") 'system-infos.ini
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

    End Sub


    Private Sub planetenbeschreibung()

        planet_target_desc = gen("\data\vars\planet_target_desc.ini") 'planetenname vorbeschreiebung
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        TextBox1.Text = TextBox1.Text + systempartname + " " 'systemsilben for planeten name einfügen

        planet_name_part = gen("\data\vars\planet_name_part.ini") 'planetenname                                 
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        planet_target_info = gen("\data\vars\planet_target_info.ini") 'planet-target-info.ini - was um den planeten so los ist..
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'boden
        planet_surface_structure_desc = gen("\data\vars\planet_surface_structure_desc.ini") 'planet-surface-structure-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_structure = gen("\data\vars\planet_surface_structure.ini") 'planet-surface-structure.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_structure_adder = gen("\data\vars\planet_surface_structure_adder.ini") 'planet-surface-structure-adder.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_structure2 = gen("\data\vars\planet_surface_structure2.ini") 'planet-surface-structure2.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'flüssigkeiten
        planet_surface_scan_liquid = gen("\data\vars\planet_surface_scan_liquid.ini") 'planet-surface-scan-liquid.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_liquid = gen("\data\vars\planet_surface_liquid.ini") 'planet-surface-liquid.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_scan_liquid2 = gen("\data\vars\planet_surface_scan_liquid2.ini") 'planet-surface-scan-liquid2.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'boden ist aus
        planet_surface_scan_material = gen("\data\vars\planet_surface_scan_material.ini") 'planet_surface_scan_material.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_material = gen("\data\vars\planet_surface_material.ini") 'planet_surface_material.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        'temperatur
        planet_surface_temperature_desc = gen("\data\vars\planet_surface_temperature_desc.ini") 'planet-surface-temperature-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        digits = gen("\data\vars\digits.ini") 'digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_temperature_adder = gen("\data\vars\planet_surface_temperature_adder.ini") 'planet-surface-temperature-adder.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        digits = gen("\data\vars\digits.ini") 'digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_temperature_adder_end = gen("\data\vars\planet_surface_temperature_adder_end.ini") 'planet-surface-temperature-adder-end.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        'wolken
        cloud_desc = gen("\data\vars\cloud_desc.ini") 'cloud-desc.ini 'wolken               
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        cloud_color = gen("\data\vars\cloud_color.ini") 'cloud-color.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        cloud_adder = gen("\data\vars\cloud_adder.ini") 'cloud-adder.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        cloud_color2 = gen("\data\vars\cloud_color2.ini") 'cloud-color2.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        cloud_adder_end = gen("\data\vars\cloud_adder_end.ini") 'cloud-adder-end.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'lebenswarscheinlichkeit
        life_possibility_desc = gen("\data\vars\life_possibility_desc.ini") 'life_possibility_desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        life_possibility = gen("\data\vars\life_possibility.ini") 'life_possibility.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

    End Sub

    Private Sub planetlanding()

        planet_surface_touchdown_scan = gen("\data\vars\planet_surface_touchdown_scan.ini") 'planet-surface-touchdown-scan.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_landing_desc = gen("\data\vars\planet_surface_landing_desc.ini") 'planet-surface-landing-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_landing_desc2 = gen("\data\vars\planet_surface_landing_desc2.ini") 'planet-surface-landing-desc2.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_landing_desc3 = gen("\data\vars\planet_surface_landing_desc3.ini") 'planet-surface-landing-desc3.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_scan_env = gen("\data\vars\planet_surface_scan_env.ini") 'planet-surface-scan-env.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_scan_anti = gen("\data\vars\planet_surface_scan_anti.ini") 'planet-surface-scan-anti.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        planet_surface_scan_anti_found = gen("\data\vars\planet_surface_scan_anti_found.ini") 'planet-surface-scan-anti-found.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

    End Sub

    Private Sub aliengefunden()

        life_alien_found = gen("\data\vars\life_alien_found.ini") 'life-alien-found.ini              'aufgabe: pulic vars vor gen stellen !!!
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_color_desc.ini") 'life-alien-color-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        gen("\data\vars\life_alien_color.ini") 'life-alien-color.ini 
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_color_adder.ini") 'life-alien-color_adder.ini 
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        gen("\data\vars\life_alien_size_desc.ini") 'life_alien_size_desc.ini 
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_size.ini") 'life_alien_size.ini 
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1



        gen("\data\vars\life_alien_desc.ini") 'life-alien-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        gen("\data\vars\life_alien_breast.ini") 'life-alien-breast.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_parts.ini") 'life-alien-parts.ini
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_legs_desc.ini") 'life-alien-legs-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_legs_count.ini") 'life-alien-legs-count.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_legs.ini") 'life-alien-legs.ini
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        ' gen("\data\vars\life-alien-legs-desc2.ini") 'life-alien-legs-desc2.ini     da simmt noch was nicht in der ini
        ' TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        ' dummy = Nothing
        ' ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_arms_desc.ini") 'life-alien-arms-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_arms.ini") 'life-alien-arms.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_face_desc.ini") 'life-alien-face-desc.ini  --------- NEW ab hier
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_face.ini") 'life-alien-face.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_face_desc2.ini") 'life-alien-face-desc2.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 3

        gen("\data\vars\life_alien_mouth.ini") 'life-alien-mouth.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_face_desc3.ini") 'life-alien-face-desc3.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_eyes_digits.ini") 'life_alien_eyes_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\life_alien_eyes.ini") 'life-alien-eyes.ini
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\alien_behavior_desc.ini") 'alien-behavior-desc.ini   'hat uns entdeckt
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\alien_behavior.ini") 'alien-behavior.ini   'wie es sich verhällt
        TextBox1.Text = TextBox1.Text + dummy + vbNewLine
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\alien_sidekick.ini") 'alien-sidekick.ini   'heirbei wird sie zynisch
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\alien_behavior_desc_add.ini") 'alien-behavior-desc-add.ini 'zumindest...
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\alien_behavior2.ini") 'alien-behavior2.ini 'macht es..
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

    End Sub

    Private Sub alienbehandlung()


        we_alien_handling = gen("\data\vars\we_alien_handling.ini") 'we-alien-handling.ini 'was wir damit machen..
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        we_alien_handling2 = gen("\data\vars\we_alien_handling2.ini") 'we-alien-handling2.ini 'was wir damit machen..
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        we_alien_handling3 = gen("\data\vars\we_alien_handling3.ini") 'we-alien-handling3.ini 'was wir damit machen..
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        we_alien_handling4 = gen("\data\vars\we_alien_handling4.ini") 'we-alien-handling4.ini 'was wir damit machen..
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        we_alien_handling5 = gen("\data\vars\we_alien_handling5.ini") 'we-alien-handling5.ini 'was wir damit machen..
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        we_alien_handling6 = gen("\data\vars\we_alien_handling6.ini") 'we-alien-handling6.ini 'was wir damit machen..
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        we_leaf_desc = gen("\data\vars\we_leaf_desc.ini") 'we-leaf-desc.ini 'warum wir gehen vom planeten.   'aktuell für test button verwendet
        test_string = we_leaf_desc
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


    End Sub

    Private Sub liftoff()

        gen("\data\vars\ship_liftoff_desc.ini") 'ship-liftoff-desc.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\ship_liftoff_orbiting.ini") 'ship-liftoff-orbiting.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\ship_liftoff_doku.ini") 'ship-liftoff-doku.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        gen("\data\vars\ship_liftoff_jumpready.ini") 'ship-liftoff-jumpready.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

    End Sub

    Private Sub weghier()

        'aufforderung den antrieb zu aktivieren
        start_jumpdrive = gen("\data\vars\start_jumpdrive.ini") 'start-jumpdrive.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

    End Sub

    Private Sub sternzeit()

        sternzeit_name = gen("\data\vars\sternzeit_name.ini") 'sternzeit_name.ini              
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1


        'aufforderung den antrieb zu aktivieren

        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini              
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits_adder = gen("\data\vars\sternzeit_digits_adder.ini") 'sternzeit_digits_adder.ini
        TextBox1.Text = TextBox1.Text + dummy + " "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1

        'aufforderung den antrieb zu aktivieren
        sternzeit_digits = gen("\data\vars\sternzeit_digits.ini") 'sternzeit_digits.ini
        TextBox1.Text = TextBox1.Text + dummy + ". "
        dummy = Nothing
        ProgressBar1.Value = ProgressBar1.Value + 1
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        GC.Collect()
        'programm init
        ProgressBar1.Value = 0
        zeile = Nothing
        dummy = Nothing
        TextBox1.Text = Nothing
        TextBox1.Text = vbNewLine + vbNewLine

        sternzeit()
        systemerreicht()
        planetenbeschreibung()
        planetlanding()

        aliengefunden()
        alienbehandlung()

        liftoff()

        weghier()


        'abschluss
        textoptimize()
        ProgressBar1.Value = 100

        If CheckBox2.Checked = True Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter("log.txt", True)
            file.WriteLine(alles)
            file.WriteLine(vbNewLine)
            file.WriteLine(TextBox1.Text)
            file.Close()

        End If


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        GC.Collect()

        Try
            ' If System.IO.File.Exists("data\sounds\background.wav") = True Then
            If CheckBox1.Checked = True Then
                My.Computer.Audio.Play("data\sounds\background.wav", AudioPlayMode.BackgroundLoop)
            End If
            '  End If
        Catch ex As Exception
            MsgBox("data\sounds\background.wav wurde nicht gefunden !" + vbNewLine + "Sie können selbst einen Sound dafür hinzufügen," + vbNewLine + "zb. Musik oder den Bridge Sound aus einer SciFi TV Serie.")
        End Try
        

        'saytext2("Sprung antrieb aktiviert.") 'dummmyyyyy !!!!!

        'aufforderung den antrieb zu aktivieren
        saytext2(gen("\data\vars\jumpdrive_activated.ini")) 'jumpdrive_activated.ini
        ' TextBox1.Text = TextBox1.Text + dummy + ". "
        'dummy = Nothing
        'ProgressBar1.Value = ProgressBar1.Value + 1

        If TextBox1.Text = Nothing Then saytext2("Ernsthaft ? Muss ich das wirklich erst erklaeren ? Na gut. Sie müssen zunächst einen Sprung berechnen. Bis dahin wird der Sprungantrieb keine Koordinaten ansteuern.")

        If CheckBox1.Checked = False Then
            My.Computer.Audio.Stop()
        End If

        saytext2(TextBox1.Text) 'play / read all

        TextBox1.Text = "Bitte berechnen Sie zunächst den nächsten Sektor Sprung." 'dummmyyyyy !!!!!

    End Sub




    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        MsgBox(Application.StartupPath + "\data\sounds\background.wav")

    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        MsgBox("Freeware by zeittresor.de" + vbNewLine + "Version 57" + vbNewLine + vbNewLine + "Bug Info:" + vbNewLine + "Das Tool friert aktuell während die Geschichte erzählt wird ein," + vbNewLine + "und ist erst danch wieder bedienbar.")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try 'lies das button
            saytext2(TextBox1.Text)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        'aufzeichnen welche strings verwendet werden und in welcher reihenfolge
    End Sub


    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = ""

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If Me.Width = 250 Then
            Me.Width = 606
            Me.Height = 529
            '606; 529
            Button6.Text = "<"
        Else
            Me.Width = 250
            Me.Height = 204
            '250; 204
            Button6.Text = ">"
        End If
    End Sub
End Class
