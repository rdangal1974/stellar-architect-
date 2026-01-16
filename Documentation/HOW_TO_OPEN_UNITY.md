# How to Open Unity Project - Detailed Step-by-Step Guide
## Stellar Architect - Unity Setup (Beginner-Friendly)

**Last Updated:** January 16, 2026  
**Estimated Time:** 5-10 minutes (first time)

---

## ?? **Method 1: Using Unity Hub (RECOMMENDED)**

### **Step 1: Open Unity Hub (2 minutes)**

#### **Option A: If Unity Hub is already installed:**
1. **Windows Start Menu:**
   - Press `Windows Key` on keyboard
   - Type: `Unity Hub`
   - Click on **Unity Hub** application when it appears
   
   OR
   
2. **Desktop Shortcut:**
   - Look for Unity Hub icon on desktop
   - Double-click it

3. **Windows Search:**
   - Click Windows search icon (magnifying glass) in taskbar
   - Type: `Unity Hub`
   - Click the application

#### **Option B: If Unity Hub is NOT installed:**
**Download Unity Hub first:**
1. Open web browser
2. Go to: https://unity.com/download
3. Click **"Download Unity Hub"** button
4. Run the downloaded installer
5. Follow installation wizard (Next ? Next ? Install)
6. Launch Unity Hub after installation

**? Checkpoint:** Unity Hub window is open

---

### **Step 2: Check if Unity Editor is Installed (1 minute)**

1. **In Unity Hub window:**
   - Look at the left sidebar
   - Click on **"Installs"** tab (icon looks like a download arrow)

2. **Check for Unity 2022.3 LTS:**
   - Look for an entry that says: **"2022.3.x LTS"** (x is any number)
   - Example: "2022.3.15f1 LTS" or "2022.3.20f1 LTS"

#### **If you SEE Unity 2022.3 LTS listed:**
- ? Great! Skip to Step 3
- Make note of the exact version (e.g., 2022.3.15f1)

#### **If you DON'T SEE Unity 2022.3 LTS:**
**Install Unity 2022.3 LTS:**

1. **In Unity Hub, still in "Installs" tab:**
   - Click **"Install Editor"** button (top-right, blue button)
   
2. **In the popup window:**
   - Scroll down to find **"2022.3 LTS"** section
   - Click **"Install"** button next to it
   
3. **Module Selection:**
   - Keep default selections (Unity Editor, Documentation)
   - Optional: Check "Microsoft Visual Studio Community 2022" if you don't have Visual Studio
   - Click **"Continue"** button
   
4. **Wait for Download & Installation:**
   - Download size: ~2-4 GB
   - Time: 10-30 minutes (depends on internet speed)
   - Progress bar shows download/install status
   - **Go make coffee and come back! ?**
   
5. **Installation Complete:**
   - Unity Hub shows "2022.3.x LTS" in Installs list
   - Green checkmark appears next to version

**? Checkpoint:** Unity 2022.3 LTS is installed

---

### **Step 3: Add Project to Unity Hub (2 minutes)**

1. **In Unity Hub window:**
   - Left sidebar: Click **"Projects"** tab (icon looks like a folder)
   
2. **Check if project already exists:**
   - Look for "stellar-architect" in the project list
   - **If you see it:** Click the project name ? Skip to Step 4
   - **If you DON'T see it:** Continue below

3. **Add the project:**
   - Click **"Add"** button (top-right corner, or center if no projects)
   - **Or:** Click dropdown arrow next to "Add" ? Select **"Add project from disk"**

4. **File Browser Opens:**
   - Navigate to: `C:\dev\steller\`
   - **Important:** Select the **`stellar-architect`** FOLDER (not a file inside it)
   - The folder should contain:
     - Assets/ folder
     - ProjectSettings/ folder
     - Packages/ folder
   - Click **"Add Project"** or **"Select Folder"** button

5. **Project Appears in List:**
   - Unity Hub now shows "stellar-architect" in the Projects tab
   - Shows project path: `C:\dev\steller\stellar-architect`
   - Shows Unity version (should say 2022.3.x LTS)

**? Checkpoint:** Project "stellar-architect" visible in Unity Hub Projects list

---

### **Step 4: Open the Project (3-5 minutes first time)**

1. **In Unity Hub, Projects tab:**
   - Find "stellar-architect" project
   - **Click ONCE** on the project card/row to select it

2. **Verify Unity Version:**
   - Check the Unity version shown under project name
   - Should say: **"2022.3.x LTS"** or **"Unity 2022.3.x"**
   - If it says different version:
     - Click the version dropdown
     - Select "2022.3.x LTS" from list
     - Click "Open with this version"

3. **Open the Project:**
   - **Method A:** Double-click the project card
   - **Method B:** Click the project once, then click "Open" button (top-right)
   - **Method C:** Right-click project ? Select "Open"

4. **Unity Starts Loading:**
   - Unity Hub might minimize
   - Unity Editor window appears (may take 30-60 seconds)
   - **You'll see:**
     - Unity splash screen (Unity logo)
     - "Opening Project" progress bar
     - "Importing Assets..." status

5. **First-Time Load (2-5 minutes):**
   - Unity is compiling scripts
   - Bottom-right corner shows: **"Compiling..."** with progress bar
   - Console tab shows: "Compiling scripts..."
   - **This is NORMAL - be patient!**
   - **Do NOT close Unity during this time**

6. **Loading Complete:**
   - Bottom-right shows: **"Ready"** or nothing (no progress bar)
   - Unity Editor is fully loaded
   - You see the main Unity interface:
     - Top: Menu bar (File, Edit, Assets, GameObject, etc.)
     - Left: Hierarchy window (shows scene objects)
     - Center: Scene view (3D viewport)
     - Right: Inspector window (properties)
     - Bottom: Project window (assets), Console window

**? Checkpoint:** Unity Editor is open and shows "Ready" (not "Compiling...")

---

### **Step 5: Verify Scripts Compiled Successfully (1 minute)**

1. **Check Console Window:**
   - Bottom panel, click **"Console"** tab
   - **Look for errors (red text):**
     - ? **0 errors:** Perfect! Continue.
     - ? **Has red errors:** See Troubleshooting Section below.

2. **Check Script Compilation:**
   - Bottom-right corner should show: **"Ready"**
   - If it shows "Compiling...", wait until it finishes
   - This can take 1-3 minutes on first load

3. **Verify Project Structure:**
   - Bottom panel, click **"Project"** tab
   - In the file browser:
     - Navigate to: `Assets ? Scripts ? Physics`
     - Should see folders: Config, Core, Components, Systems, Editor, Debug
     - Each folder should have .cs files (C# scripts)

**? Final Checkpoint:** Unity is open, no errors, scripts compiled!

---

## ?? **Method 2: Open Project from File Explorer (Alternative)**

If Unity Hub gives you trouble, try this:

1. **Open File Explorer:**
   - Press `Windows Key + E`
   - Navigate to: `C:\dev\steller\stellar-architect`

2. **Look for Unity Project Files:**
   - You should see: `Assets/` folder, `ProjectSettings/` folder
   - This confirms it's a Unity project

3. **Double-Click to Open:**
   - Find any `.unity` file (scene files) in `Assets/Scenes/`
   - Double-click it
   - Unity will launch and open the project
   - May take a moment to associate file type

**Note:** This method bypasses Unity Hub but still requires Unity Editor installed.

---

## ?? **Method 3: Open Recent Project (Fastest, if previously opened)**

If you've opened the project before:

1. **Open Unity Hub**
2. **Projects tab** ? Find "stellar-architect" in list
3. **Double-click** the project
4. Unity opens directly to your project

---

## ?? **What You Should See After Opening**

### **Unity Interface Layout:**

```
??????????????????????????????????????????????????????????????
? File  Edit  Assets  GameObject  Component  Window  Help    ? ? Menu Bar
???????????????????????????????????????????????????????????????
?            ?                                 ?              ?
? Hierarchy  ?       Scene View                ?  Inspector   ?
?            ?  (3D Viewport - gray/blue)      ?              ?
?  (Scene    ?                                 ?  (Properties)?
?   objects) ?                                 ?              ?
?            ?                                 ?              ?
???????????????????????????????????????????????????????????????
?                                                              ?
?  Project (Assets Browser)     Console (Messages/Errors)     ?
?                                                              ?
????????????????????????????????????????????????????????????????
            ? Bottom-right: Status ("Ready" or "Compiling...")
```

### **Console Should Show:**
```
Unity Version: 2022.3.x LTS
Console cleared on play.
(No red errors)
```

### **Project Window Should Show:**
```
Assets/
??? Scenes/
??? Scripts/
?   ??? Physics/
?       ??? Config/
?       ??? Core/
?       ??? Components/
?       ??? Systems/
?       ??? Editor/
?       ??? Debug/
??? (other folders)
```

---

## ?? **Troubleshooting**

### **Issue: Unity Hub won't open**
**Solution:**
1. Check if it's running in background:
   - Right-click Windows taskbar
   - Click "Task Manager"
   - Look for "Unity Hub" process
   - If found: Right-click ? "End Task"
   - Try opening again
2. Restart computer
3. Reinstall Unity Hub from unity.com/download

---

### **Issue: Project not in Unity Hub list**
**Solution:**
1. Click "Add" button in Projects tab
2. Browse to: `C:\dev\steller\stellar-architect`
3. Select the **folder** (not a file inside)
4. Click "Add Project"

---

### **Issue: "Version not installed" error**
**Solution:**
1. Unity Hub ? "Installs" tab
2. Click "Install Editor"
3. Find "2022.3 LTS"
4. Click "Install"
5. Wait for installation (10-30 min)
6. Try opening project again

---

### **Issue: "Compilation errors" when opening**
**Solution:**
1. Wait for compilation to finish (be patient!)
2. Read the FIRST error in Console (double-click to see details)
3. Check if all scripts exist:
   - Project window ? Assets/Scripts/Physics
   - Should have 12 .cs files total
4. If files missing:
   - Check Git status: `git status`
   - Restore if needed: `git reset --hard HEAD`
5. Try: Assets menu ? Reimport All
6. Restart Unity

---

### **Issue: Unity crashes on startup**
**Solution:**
1. Check system requirements:
   - Windows 10 or 11 (64-bit)
   - 8GB RAM minimum (16GB recommended)
   - Graphics card with DX11 support
2. Update graphics drivers
3. Try safe mode:
   - Hold `Alt` while double-clicking project in Unity Hub
   - Unity opens in safe mode (no addons)
4. Delete Library folder:
   - Close Unity
   - Go to: `C:\dev\steller\stellar-architect`
   - Delete "Library" folder
   - Reopen project (Unity regenerates)

---

### **Issue: Unity is VERY slow**
**Solution:**
1. Close other applications (web browsers, Discord, etc.)
2. Check Task Manager:
   - Press `Ctrl+Shift+Esc`
   - See if CPU/RAM is maxed out
   - Close heavy applications
3. Restart computer
4. Lower Unity quality:
   - Edit menu ? Project Settings ? Quality
   - Change to "Low" preset

---

## ? **Success Checklist**

Before proceeding to create scenes, verify:

- [ ] Unity Hub is open
- [ ] Unity 2022.3 LTS is installed
- [ ] Project "stellar-architect" is in Projects list
- [ ] Project opened successfully
- [ ] Unity Editor shows main interface
- [ ] Bottom-right shows "Ready" (not "Compiling...")
- [ ] Console has 0 errors (no red text)
- [ ] Project window shows Assets/Scripts/Physics/ folder
- [ ] Can see Hierarchy, Scene, Inspector, Project, Console windows

**All checked?** ? You're ready to continue!

---

## ?? **Visual Guide (What to Look For)**

### **Unity Hub - Projects Tab:**
```
???????????????????????????????????????????????
? Unity Hub                              [×]  ?
???????????????????????????????????????????????
? ? Projects    ?    ?? Installs   ? Learn  ?
???????????????????????????????????????????????
?                                             ?
?  ????????????????????????????????????????? ?
?  ? stellar-architect                     ? ?
?  ? C:\dev\steller\stellar-architect      ? ?
?  ? Unity 2022.3.15f1 LTS                 ? ?
?  ? Last modified: 1 minute ago           ? ?
?  ????????????????????????????????????????? ?
?     ? Double-click here to open           ?
?                                             ?
?  [Add ?]  Button in top-right corner      ?
???????????????????????????????????????????????
```

### **Unity Editor - Main Interface:**
```
???????????????????????????????????????????????????????
? Unity 2022.3.15f1 LTS - stellar-architect      [×] ?
???????????????????????????????????????????????????????
? File  Edit  Assets  GameObject  ...          ? ?   ? ? Play/Stop buttons
???????????????????????????????????????????????????????
?Hierarchy ?     Scene View             ?  Inspector  ?
?          ?  (Gray/Blue 3D view)       ?             ?
?[Untitled]?                            ? (Empty)     ?
?          ?                            ?             ?
???????????????????????????????????????????????????????
?Project               ? Console                      ?
?Assets/               ? No errors (green checkmark)  ?
?  Scenes/             ?                              ?
?  Scripts/            ? "Ready" in bottom-right ?  ?
???????????????????????????????????????????????????????
```

---

## ?? **Next Steps After Opening Unity**

Once Unity is open and ready:

1. **Continue with:** `Documentation/WEEK2_DAY1_CHECKLIST.md`
2. **Start at:** Phase 3 (Create PhysicsConstants Asset)
3. **Expected time:** 15 minutes to first working physics!

---

## ?? **Still Need Help?**

### **Common Questions:**

**Q: How do I know Unity Hub is installed?**
A: Windows Start ? Type "Unity Hub" ? Should appear in results

**Q: Which Unity version exactly?**
A: Any 2022.3.x LTS version works (e.g., 2022.3.15f1, 2022.3.20f1)

**Q: Can I use Unity 2021 or 2023?**
A: 2021.3 LTS might work, but 2022.3 LTS is recommended. 2023+ may have compatibility issues.

**Q: How long does first-time opening take?**
A: 3-5 minutes typical, up to 10 minutes on slower computers

**Q: Unity froze, what do I do?**
A: Be patient! Check if "Compiling..." is showing. If truly frozen (10+ min no change), restart Unity.

---

**?? That's it! Once Unity is open and shows "Ready", you're good to go! ??**

**Next:** Follow `WEEK2_DAY1_CHECKLIST.md` starting at Phase 3

**Last Updated:** January 16, 2026
