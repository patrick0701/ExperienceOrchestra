# ExperienceOrchestra
3DUI IEEE VR Competition

For Sprint1, our goal was to set up the basics of the game, including introductory menu selections, proximity detection of objects, importing assets of instruments, and creating enough of the environment to allow for player movement. As we began Sprint1, we made some modifications from the initial design based on guardians

Link to Sprint 1 Video: https://drive.google.com/file/d/1YCXhLuu0KMJMVktfUprmjvxdr6qQ0ob5/view?usp=sharing

Individual Roles:

Kristine: Created medium-fidelity UI sketches for each interface and specified interactable components in order to create tasks and issues for the project board. Gathered all assets for instruments and imported string instruments to connect to proximity triggers.

Raahul: Created play ensemble multiplayer lobby scene using Normcore. Integrated instruments assets, proximity trigger script, and stage assets to design initial scene for string instruments in the Play Instrument scene. Added basic player teleportation.

Garrett: Created a main menu user interface, page to choose an instrument, and a page to create an ensemble. The pages are connected to each other via buttons, and the instrument choice can be passed to future scenes.

Richard: Created the stage in blender, and imported the .fbx file. Also found assets of chairs and curtains and imported those.

Patrick: Created the Proximity Trigger scripts that can be used for assets, which pops up the text when user walks into the sphere collider.

Group Work:

As a group, we came together to merge individual items and created a flow from the main landing page to the different components of the project. We also tested out the multiplayer component to make sure that the basic capabilities for playing in an ensemble were solid. Because our proejct includes a critical component for multiplayer ensemble playing, we made sure to get a headstart on this and Raahul took leadership in this particular component.

Moving Forward:

For the upcoming Sprints, we plan on extending what we implemented for the string instruments to other categories of instruments as well as to deep dive into the sound component-- implementing audio, manipulating pitch, and controlling volume.

Sprint2
For Sprint2, our goal was to create a basic prototype of our experience. We focused on the mechanics of the string instruments and the music they produced, as well as locomotion within our environment. We also aimed to create the entire orchestra hall, including chairs and lighting. Additionally, we constructed menu selections that load in different selections of instruments based on the users' choices along with a pause menu to allow users to stop and restart their gameplay.

Link to Sprint 2 Video: https://drive.google.com/file/d/1JQLMXjmiCaGyvmgEjBgnN4URuMIOlL68/view?usp=sharing

Individual Roles:

Kristine: Collected and compiled the rest of the assets for orchestral instruments as well as audio files usable for each instrument. Redirected the vision/ plan for the ensemble component into having presets (such as a string quartet) and gathered appropriate audio for different ensemble types. Started working on the menu UI for choosing ensemble type.

Raahul: Made the violin playable in virtual reality. Completed the tempo management system for string instruments. Provided the template for instrument playing for others to implement and adjust.

Garrett: Made the cello and double bass playable in VR. Made it so that the proper instruments show up in the playInstruments scene based on the group selected.

Richard: Finalized construction of the orchestra stage. Aimed to recreated the mood and tone of performing on-stage in a professional orchestra hall. Scene includes lighting and seating.

Patrick: Created teleportation, locomotion and hand presence for the player. Created a simple pause menu that lets the player switch scenes, quit the game, resume back to the menu and go back to the beginning of the game.

Group Work:

After we all completed our individual tasks, we met together and worked on combining our work into one complete unity project. Adding the all the individual contributions took a lot of work and we were met with some challenges such as file sizing and management. Raahul took particular leadership in this accomplishment.

Moving Forward: Moving forward for Sprint 3, we wish to continuing adding in more instruments into our experience beyond those of the strings. We aim to flesh out our menu selections and decrease load times. We also will finalized our multiplayer experience and musical selection.

Sprint3
For Sprint3, our goal was to complete implementing the fundamental functionalities required for each component of our project. For the first component, "Explore Instruments," we made every instrument playable; this included designing and implementing each instrument in a way that would make sound when the user holds the instrument properly. For the second component, "Play in an Ensemble," we decided to take the route of implementing a preset ensemble configuration-- a string quartet. We made this decision because a string quartet epitomizes one of the most commonly found ensemble types and we were able to implement the ensemble in a way that four users would be able to play and create music collectively. Furthermore, we made improvements to the symphony hall that serves as the background scene.

Link to Sprint 3 videos: https://drive.google.com/file/d/1j-Lx7E4NS9GaHGTzP62PxJhbmXmyIX-K/view?usp=sharing https://drive.google.com/file/d/1zlqzf0HqLNXaPqvjBM0VzTbDyMWu8mq7/view?usp=sharing

Design:

Purpose: Experience Orchestra is meant to dismantle the glass ceiling of entering the world of classical music and give all users-- regardless of their background or SES-- a chance to immerse themselves in a symphony by learning what instruments exist, how they work and how they sound, and playing with other musicians in an ensemble.

Entry Point: The very first thing the user sees is a symphony hall that we created on Blender. Choosing a symphony hall as the entry point was a deliberate decision, as the purpose of Experience Orchestra is to provide the user with an opportunity to experience a symphony environment in its entirety-- we were inspired by the power of Virtual Reality to give an experience that is not accessible to everyone in reality. We wanted to go beyond providing a user experience of hearing what each instrument sounds like in a symphony orchestra and build a holistic experience that empowers users to dream about the possibilities of pursuing classical music.

Components: In addition to the symphony hall background, there are two main components to the start screen: 1) explore instruments, and 2) play in an ensemble. The “explore instruments” button takes the user to each instrument family (strings, woodwinds, brass, and percussion). Our initial design included the entire stage and all instruments present on the stage; however, taking into account the space and boundaries limitations, we pivoted our direction into categorizing the instruments by groups. This way, the user experience would not be jeopardized by the potential technical roadblocks. Furthermore, providing users with the opportunity to play in an ensemble with other musicians was the perfect way to incorporate multiplayer capabilities to our design.

Interactables: The interactions are designed to mimic how instruments work in real life.

Individual Roles:

Kristine: Trimmed all audio files in a way that made sense for quality user experience while making sure files were not too big that would cause a lag; combined with the size of all audio files with the total poly count for all instrument models, it was important to modify the music files in a way that would meet design goals on the user experience side while tackling lagging and increased loading time. Using an audio sample found online for a string quartet (four instrments), used the digital audio software tool Logic Pro to separate stems for each instrument and create isolated audio files for the ensemble component. Completed design documentation.

Raahul: Created scripts for playing wind and brass instruments as well as controlling tempo using the rate at which the user presses buttons. Create ensemble multiplayer lobby with networked physics for the instruments and XR interactions. Create scripts to network audio over Normcore and scripts to play all instruments in a multiplayer environment. Developed scripts in a way so that data consistency is maintained and multiplayer system does not lag. Implemented scripts to create the string quartet ensemble gameplay composed of two violins, viola, and cello.

Garrett: Took the scripts that Raahul made and implemented them with the wind instruments (oboe, flute, bassoon) and the percussion instruments (timpani, triangle, cymbal). Simplified some of the instrument colliders to reduce game latency and lag. Fine tuned instrument mechanics and tempo control hyperparameters.

Richard: Reduced size and number of polygons and assets in the stage environment prefab to reduce lag. Implemented Raahul's script to make the brass instruments (trumpet, tuba, baritone, french horn) playable. Combined the menu scenes to reduce scene overhead.

Patrick: Wrote up instructions for how to play all the instruments that will pop up when the user is near the instruments.

Group Work: After dividing up the tasks at the end of Sprint 2/ beginning of Sprint 3 and completing individually assigned tasks, we came together to merge all components together into one unity project, similarly to how we have been systematically working in previous sprints.

Moving Forward: As the main goal for sprint 3 was to implement our Minimum Viable Product, for Sprint 4 we plan to push further beyond the highest priority features and shift our focus to building a better user experience with improved UI. As we are approaching the finish line before we enter the testing and debugging stage, sprint 4 will focus on improving and solidifying the user-facing interactions and components.

Sprint4
For Sprint 4, our primary objective was to expand upon what we had accomplished for sprint 3 and push to achieve more than just the MVP; since we had the fundamental features down for sprint 3 for the backend, we focused on making sure the interface would create the most optimal user experience. This included modifying components of the environment (symphony hall) such as lighting, integrating individual aspects of the project all into one, and finetuning all instruments to make sure they are playable the way they are intended to be played. Throughout the 4 sprints we were able to stay on track with what we wanted to accomplish for each sprint and we are excited to see how the project idea came to fruition.

Link to Sprint 4 videos: https://drive.google.com/file/d/1-G28x9nq2jDYb03upAjSH_2tJmxcqh_4/view?usp=sharing https://drive.google.com/file/d/1PiXltOa-M-2JLrZDvVq5dVc6kUlgOiHu/view?usp=sharing

Design:

As stated above, the reason for choosing a symphony hall as our environment was because we not only wanted to build an experience that would allow users to explore and listen to each instrument but also go further beyond the act of playing itself and encourage users to stay curious about the world of classical music. This project is meant to be a starting point of one's classical music journey, and every design decision we made centers around this primary goal.

We had a lot of conversations and discussions around arrangement and configuration. One area was separating instruments by family (strings, winds, brass, and percussion) vs. having every instrument present on the stage. After much deliberation and trying out the options, we ultimately decided that separating instruments was the best way to go for three main reasons: 1) due to the limitation of space, we didn't want the user to have to feel like s/he was in a crowded space; 2) on the backend, we were facing issues with loading time because of the high polycount of each instrument model; 3) compounded was the extended loading time due to the sheer volume of audio files we had, we decided that having every instrument on stage would lower the overall quality of experience that the user would have.

Furthermore, the decision to leave space between each instrument when one enters each instrument family was intentional as well. We concluded that the instructions on how to properly hold the instrument that appear when the user approaches the instrument required enough space so that they were legible. We also noticed that if they were too close together there would be too much empty space. Finally, we wanted users to be able to feel like every time they picked up an instrument they had a soloistic feel, and having too little space between each instrument did not aciheve this goal as well as having enough space.

As a team, we took Kristine's original design and made appropriate modifications to create the most ideal user experience while also taking in account the realities of implementing everything. Another major area of making design decisions was free play vs. music play, in which free play refers to being able to manipulate the pitch based on some control that the user makes (e.g., distance between the controller and the user) whereas music play refers to an audio clip corresponding to each instrument. The technical roadblock we faced was that this area of sonic control and manipulation is still an evolving field in VR, and there was simply not enough resource and time to be able to implement that for every single instrument. Additionally, and more importantly, our goal for this project and what we want our user to experience is understanding how each instrument sounds like and to foster greater aspirations to want to pursue classical music, so we concluded that implementing music play as a solution fit better to our objective.

Individual Roles:

Kristine: finalized audio for the instruments, including the addition of the euphonium for the brass section. Finalized UI/UX decisions based on the original pitched project to make sure the goal of Experience Orchestra was met. Completed the design documentation.

Raahul: Set up baked lighting for all scenes, experimented with global illumination in order to create a cleaner aesthetic. Fixed networked audio issues to handle concurrent music. Set up asynchronous scene loading for Ensemble scene to prevent freezing in game.

Garrett: edited UI canvases to fit in with the added environment, added loading spinner while waiting for scene to load, cleaned up file structure to get rid of unused files

Richard: modified the environment to better suit player experience, added background settings to the main menu, editted lightning and shading in the main environment

Patrick: Used a font asset creator to import font assets to experiment on the fonts, modified the text TMP settings to load the fonts and make them look better, changed the fonts for the main menu, ensemble scene, etc, and font sizes and coloring for all of them.

Group Work: Since we shifted our focus from making sure the instruments were playable and the multiplayer feature was working, we focused on having discussions about what design choices we were making from a user-centric perspective. We came together and ensured that every design decision was intentional and justified. As a collective, we reached an agreed upon design solution that would allow users to explore every orchestral instrument as initially envisioned.

Playtesting
During playtesting, we mostly focused on fixing bugs in the project. In addition to bugfixes, we made the instructions more clear for the user, added a snap back return when the instruments are released, changed the mixers in ensemble mode for each instrument to have its own mixer, and fixed some issues with the songs.
