# Design Justification

## 1. Design purpose

Nepsy Test was designed as a Meta Quest 3 virtual-reality activity to support psychologists who monitor the progress of patients with ADHD. During a remote meeting, a psychologist described the test activity, supplied the instructions used in their work, and identified the response metrics that the team needed to include.

The design goal was to translate the activity into a clear, complete VR flow while keeping the psychologist in charge of interpreting the results. The application automates the presentation of audio stimuli and the tally of selected response metrics during a session; it does not provide a diagnosis or clinical interpretation.

## 2. Interface and visual decisions

### 2.1 A clear sequence of screens

The interface separates the experience into a start screen, mode selection, mode-specific instructions, the assessment itself, and a results screen. Each screen has a clear next action. This gives users a guided path through the main flow rather than presenting all controls and rules at once.

![Start screen](screenshots/start-screen.jpg)

![Mode selection](screenshots/mode-selection.jpg)

### 2.2 Separate instructions for each mode

Basic and Advanced use the same number of stimuli and the same activity duration, but they require different response mappings. The rules are therefore shown on separate instruction screens before the activity begins. This makes the selected rule explicit at the point where the user needs to learn it.

The instructions disappear when the activity starts, so users must remember the selected rule while responding. This is part of the task, but it also creates a reliance on working memory and is a design trade-off rather than an attempt to eliminate recall.

![Basic instructions](screenshots/basic-instructions.jpg)

![Advanced instructions](screenshots/advanced-instructions.jpg)

### 2.3 Typography and visual environment

The team chose simple, readable lettering for instructional content so that the text would be straightforward to read and would not add unnecessary visual distraction. The screens place the text and buttons on a translucent panel over a low-poly outdoor environment with trees, grass, and flowers. The colored ducks are red, green, and blue, matching the color-word task.

The use of ducks was inspired by the game *Duck Hunt*. This familiar game-like interaction provides an intuitive context for aiming and shooting, while the audio-word rules define when the user should act.

The team did not record a specific typeface, font size, color-contrast measurement, or formal accessibility evaluation. The choice of simple lettering is therefore documented as a design intention, not as a measured accessibility result.

### 2.4 One response input in VR

The user aims in the virtual environment and presses the Meta Quest 3 controller trigger to shoot. The trigger is the only controller input used to respond during the test. The team used Unity's VR template as the basis for the virtual-reality setup.

This keeps the response interaction limited to one input, although aiming in three-dimensional space still requires users to understand how to orient the controller toward a duck.

### 2.5 Results screen

When the audio sequence finishes, the application displays the total correct responses, commission errors, omission errors, inhibition errors, and total time. A `Main menu` button returns the user to the beginning of the experience.

The results screen presents metrics without automatically interpreting them. This was intentional because the psychologist is expected to interpret the numbers. The application does not save session history, so the psychologist records the results manually.

![Results screen](screenshots/results-screen.png)

## 3. HCI concepts applied

The following concepts connect specific implementation decisions to HCI. They describe how the interface is designed; they are not claims that the prototype has been clinically validated or that its usability has been proven for all intended users.

### 3.1 Cognitive load and working memory

**Design evidence:** The instructions are separated by mode and presented on their own screen before the task. The instructional text is kept straightforward, and the main interaction uses a single controller trigger.

**Connection to HCI:** Separating instructions from the active task can reduce the amount of information that must be processed at the same time. However, because the instructions disappear during the assessment, the user must retain the rule in working memory. This is particularly relevant in Advanced mode, where the RED and GREEN responses are reversed. The design simplifies the presentation of the rule but does not remove the memory demand of the task.

### 3.2 Perception, attention, and response selection

**Design evidence:** The activity combines spoken color words with visual red, green, and blue ducks. The user must listen to each word, identify the corresponding rule, locate the appropriate duck, and decide whether to respond.

**Connection to HCI:** This interaction uses auditory and visual information together and requires selective attention and response selection. Advanced mode adds a reversed mapping for RED and GREEN, so it places a different response-selection demand on the user than Basic mode. These are characteristics of the task design, not a claim that the application measures or diagnoses a cognitive condition on its own.

### 3.3 Feedback

**Design evidence:** When a duck is hit, it disappears. At the end of the activity, the results screen presents the response counts and total time.

**Connection to HCI:** The disappearing duck gives immediate visual feedback that an interaction has affected the environment. The final screen gives summary feedback about the session. The application does not provide a live numerical score or a running progress indicator during the activity.

### 3.4 Visibility of system status

**Design evidence:** The user moves through identifiable states: start, mode selection, instructions, active assessment, and results. Completion of the audio sequence leads to the results screen.

**Connection to HCI:** The screen sequence communicates where the user is in the overall flow and makes the next step visible. There is no visible progress bar, remaining-stimulus count, or on-screen timer during the activity, so the status information is stronger at screen transitions than during the test itself.

### 3.5 Consistency and predictable interaction

**Design evidence:** Both modes follow the same screen sequence, use the same controller trigger, and share the same timing and number of stimuli. Only the response rules change.

**Connection to HCI:** Keeping navigation and physical input consistent means users do not need to learn a different control scheme for each mode. The separate instruction screens communicate the one important difference: the color-to-response mapping.

### 3.6 Affordances, signifiers, and mapping

**Design evidence:** The screens use labeled buttons such as `Start`, `Basic`, `Advance`, and `Main menu`. The instructions explicitly tell users to press the controller trigger to shoot. The trigger action is mapped to firing at the duck being aimed at.

**Connection to HCI:** Button labels signal what will happen when selected, while the trigger instruction identifies the physical input required. The mapping between aiming, pressing the trigger, and shooting is consistent with the game's interaction metaphor.

## 4. Platform-specific interaction

The experience was developed for Meta Quest 3 using Unity's VR template. The user interacts inside a three-dimensional environment and uses the headset controller's trigger rather than a keyboard, mouse, or touchscreen. The colored ducks move during the activity, so the user must aim in the virtual scene before shooting.

During usability testing, the main point of uncertainty reported by testers was how to aim before shooting. This is relevant to VR because aiming requires spatial orientation in the virtual environment. The team did not report technical problems during testing, but aiming guidance remains a possible area for future refinement.

## 5. Limitations and future considerations

- Instructions are shown before the activity and are not available as an overlay during the test. This preserves the task's memory demand but may make the rule harder to recover if a user forgets it.
- The active test has no pause or restart control.
- There is no visible timer or progress indicator while the activity is running.
- Results are not stored between sessions; the psychologist must record them manually.
- Testers identified aiming as the least clear part of the interaction. A future version could make the aiming method more explicit before the test begins.
- The project did not include a formal accessibility evaluation, a clinical validation study, or usability testing with a confirmed ADHD patient sample.

## 6. Figma prototype

The Figma prototype contains the complete main flow: start screen, mode selection, Basic instructions, Advanced instructions, assessment screen, and results screen.

[Open the Nepsy Test Figma prototype](https://www.figma.com/design/yFqMirPqeeeYdRU2VKNOVN/HCI-Final-Project?node-id=0-1&t=xXbdvt43P9nuFRRg-1)

## 7. Design summary

The design prioritizes a guided screen sequence, short mode-specific instructions, a single VR response input, immediate visual feedback when a duck is hit, and a final screen that exposes the metrics requested by the consulting psychologist. The same structure is used in both modes to keep navigation consistent, while the changed response mapping creates the intended difference between Basic and Advanced. The current prototype also has clear limitations: it does not preserve results across sessions, show live progress, or explain aiming beyond the trigger instruction and in-world interaction.
