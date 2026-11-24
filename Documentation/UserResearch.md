
# User Research

## 1. Research objective

The project began with a need identified through consultation with a psychologist: supporting the monitoring of progress in patients with ADHD through a more practical way to administer a color-and-word response activity and collect its basic performance metrics.

The purpose of the research was to understand the existing activity, identify the information the psychologist needed to review, and translate those needs into a realistic Unity VR prototype.

## 2. Participant and method

- **Participants consulted:** One psychologist.
- **Method:** One remote meeting through Google Meet.
- **Materials shared:** The psychologist described the NEPSY test activity used in their work, explained the two task versions and the response rules, identified the results that needed to be measured, and shared the instructions used by psychologists.
- **Follow-up:** The psychologist reviewed the project/prototype and gave positive overall feedback. No specific change request was reported.

The consultation was a focused, qualitative conversation. The team did not conduct a formal multi-participant interview study, patient observation, survey, or clinical evaluation. No verbatim interview transcript or direct patient quotes were collected.

## 3. Key findings

### 3.1 Monitoring progress is the central need

The psychologist identified monitoring patient progress as the main purpose the project could support. The application therefore focuses on presenting the activity and making session metrics available at the end.

### 3.2 The existing manual process was considered time-consuming

The psychologist described carrying out the activity manually as more time-consuming and impractical. This informed the decision to implement the presentation of stimuli and the counting of selected responses in Unity.

### 3.3 The original task rules and measures needed to be preserved

The psychologist described two task versions, which the team implemented as Basic and Advanced modes. The two modes use the same number of stimuli and the same duration; their response rules differ. The psychologist also identified the metrics that should appear at the end of a session:

- Total correct responses
- Total commission errors
- Total omission errors
- Total inhibition errors
- Total time

### 3.4 Professional interpretation remains necessary

The results screen presents counts and time only. The psychologist is responsible for interpreting the numbers. The application does not provide an automated clinical explanation or diagnosis.

### 3.5 Feedback on the prototype was positive

The psychologist reviewed the project/prototype and expressed positive overall approval. The team did not receive a specific request for changes, so no design or functionality changes were made as a direct result of that review.

## 4. User needs derived from the consultation

| Identified need | Evidence from consultation | Design response |
|---|---|---|
| Support monitoring of patient progress | The psychologist identified progress monitoring as the main purpose. | Show session metrics at the end of the activity. |
| Make the activity less dependent on manual administration | The manual process was described as time-consuming and impractical. | Present audio stimuli and moving colored ducks in a Unity VR activity. |
| Preserve both task versions | The psychologist explained that the test activity includes two versions with different response rules. | Provide Basic and Advanced modes with separate instruction screens. |
| Record the measures needed by the psychologist | The psychologist identified the five result fields. | Count correct responses, three error categories, and total time. |
| Keep result interpretation with the professional | The psychologist is familiar with interpreting the measures. | Display the counts and time without adding automated interpretation. |

The current prototype does not save results between sessions. The psychologist must manually record the displayed metrics if they are to be used for progress monitoring over time. This is an important limitation relative to the broader need.

## 5. Customer journey

The journey below summarizes the psychologist's workflow and the intended role of Nepsy Test. The consultation established the general need and the time burden of manual administration, but it did not collect detailed observations of every step. Therefore, thoughts and emotional responses are identified as **inferences**, not direct quotes or measured feelings.

| Stage | Actions and touchpoints | Friction or need | Thoughts / emotions |
|---|---|---|---|
| 1. Prepare the activity | The psychologist prepares to administer the activity using the instructions and materials associated with the existing test. | The existing manual procedure was described as time-consuming and impractical. | **Inferred:** the psychologist needs a workflow that is practical to set up. No direct emotional description was collected. |
| 2. Explain and administer the task | The psychologist provides the task instructions and the patient completes the color-and-word activity. The touchpoint is the test procedure and its instructions. | The activity must follow the two task versions and their specific response rules. | **Inferred:** clear, consistent instructions are important. The consultation did not record the psychologist's or patient's emotional state during this stage. |
| 3. Capture performance | Responses and the relevant metrics are recorded: correct responses, commission errors, omission errors, inhibition errors, and time. | Manual handling of the activity and its results adds time. | **Inferred from the stated need:** a more streamlined way to collect the metrics would be useful. No feeling or direct quotation was recorded. |
| 4. Review and interpret results | The psychologist reviews the recorded measures and interprets them using professional knowledge. | The tool should present the required values clearly without replacing professional interpretation. | **Inferred:** the psychologist needs results that are easy to identify and review. No formal emotion or satisfaction measure was collected. |
| 5. Monitor progress | The psychologist uses recorded results as part of monitoring the patient's progress over time. The current app does not retain session history. | Results must be recorded manually outside the application if they are to be compared across sessions. | **Inferred:** having accessible records across sessions may be valuable. This need was not explored in detail during the single meeting. |

### Evidence and limitations of the journey

The time-consuming nature of manual administration, the need to monitor patient progress, the two task versions, and the required output metrics were reported by the psychologist. The detailed stage-by-stage thoughts and emotions were not directly researched. They are shown above only as cautious hypotheses to make the journey useful for design discussion; they must not be treated as participant quotations or measured user states.

## 6. How the research influenced the solution

The consultation informed the project in several direct ways:

1. **Audience and purpose:** Psychologists were identified as the primary professional users, with patients with ADHD as the intended participants in the activity.
2. **Task structure:** The team implemented the two versions described by the psychologist as Basic and Advanced.
3. **Stimuli and response logic:** The team used the color-word rules explained during the meeting.
4. **Result fields:** The final screen includes the five measures identified by the psychologist.
5. **Professional role:** The application displays the values but leaves interpretation to the psychologist.

The psychologist's positive review did not lead to a specific design change. The team kept the implementation as it was after receiving that feedback.

## 7. Research limitations and scope

- The research involved one psychologist and one remote meeting. Findings are useful for understanding this project's starting requirements but cannot represent all psychologists' needs.
- No patients with ADHD were interviewed or observed during the research described here.
- The team did not collect formal measures of user satisfaction, emotion, task duration, or clinical outcome during the research phase.
- The prototype does not save results across sessions, even though the broader project goal is to support progress monitoring.
- The project is a VR prototype based on the psychologist's description. This document does not claim that it reproduces the full standardized NEPSY assessment or that it has been clinically validated.
