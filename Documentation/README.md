# Nepsy Test

**Course:** Introduction to Human Computer Interaction  
**Platform:** Meta Quest 3 (VR)  
**Engine:** Unity 6000.5.4f1

## Project overview

Nepsy Test is a virtual-reality prototype designed to support psychologists who monitor the progress of patients with ADHD. It translates a color-and-word response activity described to the team by a consulting psychologist into an interactive VR experience.

The project was created in response to feedback that administering the activity manually can be time-consuming and impractical. In the application, audio stimuli are presented at regular intervals, colored ducks appear and move in a 3D environment, and the user responds by aiming and pressing the trigger on the Meta Quest 3 controller. The application automatically counts selected response metrics and displays them when the activity ends.

Nepsy Test is a prototype to support a psychologist's work. It does **not** diagnose ADHD, replace professional assessment, provide a clinical interpretation, or claim to reproduce a clinically validated standardized administration. The psychologist remains responsible for interpreting the results.

## Intended users

- **Primary users:** Psychologists who administer activities and review performance metrics to help monitor patient progress.
- **Participants:** People taking part in the activity, with patients with ADHD as the intended population described during the project research.

The usability test described in `UserTesting.md` involved two convenience testers, not a clinical sample. Their feedback should not be interpreted as evidence of clinical effectiveness or suitability for every patient.

## Main features

- VR experience designed for Meta Quest 3.
- Two task modes: Basic and Advanced.
- Mode-specific instructions shown before the activity.
- Repeated audio words played at regular intervals.
- Red, green, and blue ducks that appear and move during the activity.
- Controller-trigger input to shoot the selected duck.
- Visual feedback: a duck disappears when it is hit.
- Automatic tally of response metrics and total time.
- Results screen with a button to return to the main menu.

## Application flow

1. **Start screen:** The user selects `Start`.
2. **Mode selection:** The user chooses `Basic` or `Advance` (the button label shown in the interface; referred to as Advanced mode in this documentation).
3. **Instructions:** The corresponding rules are displayed. The user selects `Start` to begin.
4. **Activity:** Audio words are played repeatedly at equal intervals while colored ducks appear and move in the environment. The user follows the selected mode's rules and uses the controller trigger to shoot when required.
5. **Results:** After the audio sequence finishes, the results screen displays the recorded metrics. The user can select `Main menu` to return to the beginning.

The two modes use the same activity duration and number of stimuli. Their difference is the response rule. The application does not provide pause or restart controls during an activity.

## Task instructions

### Basic mode

> During this test, you will hear different words. When you hear the word RED, you must shoot the RED duck. When you hear any other word, do nothing. To shoot, press the trigger.

<img width="1253" height="607" alt="WhatsApp Image 2026-11-22 at 17 09 47" src="https://github.com/user-attachments/assets/c3819b59-d4d5-4f5e-9de0-f25cbdb1c18b" />

### Advanced mode

> During this test, you will hear different words. When you hear RED, you must shoot the GREEN duck. When you hear GREEN, you must shoot the RED duck. Finally, when you hear BLUE, you must shoot the BLUE duck. When you hear any other word, do nothing. To shoot, press the trigger.

<img width="1270" height="599" alt="WhatsApp Image 2026-11-22 at 17 57 59" src="https://github.com/user-attachments/assets/309a9cc7-060e-4573-8f43-9a56b7ce044f" />

## Controls

| Input | Action |
|---|---|
| Meta Quest 3 controller trigger | Shoot the duck being aimed at |
| Start / Basic / Advance / Main menu buttons | Navigate the application screens |

The trigger is the only controller input used to respond during the activity. The user must aim at a duck before shooting. The application detects the color of the duck hit. Shots made before an audio prompt are also registered and contribute to the results; the precise counter-classification for each type of early or incorrect response is determined by the application's implementation.

## Results

The final screen displays:

- Total correct responses
- Total commission errors
- Total omission errors
- Total inhibition errors
- Total time

The application displays counts and elapsed time only. It does not interpret the results or provide a clinical assessment. The psychologist interprets the metrics and records them manually. Results are not saved by the application: they disappear when the session is closed, and previous sessions cannot be retrieved from the app.

The team described the categories as follows: a **commission error** occurs when the user shoots when no action is required; an **omission error** occurs when the user does not shoot when a response is required; and an **inhibition error** occurs when the user shoots the wrong duck or responds to a word that requires no action. The application maintains separate commission and inhibition counters. Because the descriptions of commission and inhibition overlap conceptually, the exact code-level conditions that distinguish their counters should be checked against the Unity implementation before making a more precise technical claim.

<img width="937" height="558" alt="Screenshot 2026-11-23 at 6 52 48 PM" src="https://github.com/user-attachments/assets/76768b42-514e-44ed-a314-14c96e8a4974" />

## Screenshots

### Start screen

<img width="1218" height="606" alt="WhatsApp Image 2026-11-22 at 17 04 18 (1)" src="https://github.com/user-attachments/assets/846dda78-66cb-4a56-a32a-e13bf92f1247" />

### Mode selection

<img width="1265" height="611" alt="WhatsApp Image 2026-11-22 at 17 08 51 (1)" src="https://github.com/user-attachments/assets/370b900a-a39a-4a78-ad59-7247a8a6f6ae" />

### Basic instructions

<img width="1253" height="607" alt="WhatsApp Image 2026-11-22 at 17 09 47" src="https://github.com/user-attachments/assets/6166aacf-08fd-4c79-ba8f-76d907a6bc5c" />

### Advanced instructions

<img width="1270" height="599" alt="WhatsApp Image 2026-11-22 at 17 57 59" src="https://github.com/user-attachments/assets/0c957323-2efe-42d0-a6d6-f1f921721d5f" />

### Assessment in progress

<img width="910" height="536" alt="image (3)" src="https://github.com/user-attachments/assets/c418c257-0d4b-44e7-96dc-68469e6f5422" />

### Results

<img width="937" height="558" alt="Screenshot 2026-11-23 at 6 52 48 PM" src="https://github.com/user-attachments/assets/d7341af6-a637-49d5-b828-f0c8b69a27e1" />

## Figma prototype

The Figma prototype represents the complete main flow: start screen, mode selection, Basic instructions, Advanced instructions, assessment screen, and results screen.

https://www.figma.com/design/yFqMirPqeeeYdRU2VKNOVN/HCI-Final-Project?node-id=0-1&t=xXbdvt43P9nuFRRg-1

## Requirements and execution

### Requirements

- Unity **6000.5.4f1** to open and work with the project.
- A Meta Quest 3 headset.
- A compatible computer with the project's VR/headset connection configured.
- The Unity project and its existing XR configuration.

### Running the application

The team runs the experience with the Meta Quest 3 connected to a computer; it is not installed and launched as a standalone headset application in the workflow documented for this project.

1. Open the Unity project using Unity 6000.5.4f1.
2. Connect the Meta Quest 3 to the computer using the VR connection setup configured for the project.
3. Make sure the headset connection and the project's XR runtime are active.
4. Launch the experience using the run configuration already set up in the Unity project.
5. Put on the headset and follow the on-screen buttons and instructions.

The specific connection software, driver setup, Unity build target, and launch configuration were not recorded in the information provided for this documentation. The steps above describe the team's connected-headset workflow; anyone setting up the project on a new computer should verify the project's XR settings and required Meta/PC runtime first.

## Team and contributions

| Team member | Contributions |
|---|---|
| Fátima Walls | Figma prototype, documentation, and implementation of some menu screens in Unity. |
| Heidi Meiners | Initial screen design, audio implementation, and timer implementation. |
| Alberto Dubin | Main game functionality, shooting mechanics, and response counting. |

All three team members worked in Unity. The team coordinated through GitHub and work meetings.

## Repository documentation

- [`README.md`](README.md) — Project overview and execution information.
- [`DesignJustification.md`](DesignJustification.md) — Interface decisions and HCI concepts.
- [`UserResearch.md`](UserResearch.md) — Psychologist consultation, findings, and customer journey.
- [`UserTesting.md`](UserTesting.md) — Usability test participants, tasks, observations, and limitations.
- [`AIUsage.md`](AIUsage.md) — Declaration of AI tools and human review.
