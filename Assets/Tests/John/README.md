# Spacewar! README

> Big README for every idea we come up with for this game

## Dependency Injection

Начинаем с **Abstract Bootstrapper**. Создаем **IoCContainer** - большой страшный класс, который мне точно нужно разобрать.

### IoC Container

**IoCContainer** наследует три интерфейса, которые нужно тоже разобрать:
- *IIoCContainer*
- *IServiceLocator*
- *IDependencyInjector*



## Doing stuff

**На чем остановился** - [2D Sorting](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/2DSorting.html).

## 2D

### 2D-камера

В 2D режиме есть специальная ортогональная камера, которая ставится по оси Z и представляет удобный способ редактировать игровую сцену с точки зрения 2D-перспективы.

### 2D-графика

Графические объекты в 2D игре называются **спрайтами**. Это просто стандартные текстуры, но есть дополнительные инструменты для облегчения работы с ними, как, например, **Sprite Editor**. Спрайты рендерятся **Sprite Renderer** компонентом, вместо **Mesh Renderer**, использующегося для 3D-объекта. Также можно использовать **Sprite Creator**, чтобы создать спрайты-плейсхолдеры для игровых объектов.

### 2D-физика

Unity имеет отдельный физический движок для просчета 2D-физики. Компоненты остались практическими такими же, как, например, **Rigidbody**, **Box Collider** или **Hinge Joint**, но с 2D, присобаченным к их именам. Так что спрайты могут быть с компонентами **Rigidbody2D**, **Box Collider 2D** или **Hinge Join 2D**. Большая часть физических объектов в 2D просто «сглаженная» версия 3D-эквивалентов, но есть несколько исключений.

## TODO

The Unity is:
- Unity Engine
- Unity Editor

The Unity Documentation is:
- Unity User Manual
- Unity Scripting API

- **Unity TODO**
  - [Unity Tutorials](https://unity3d.com/learn/tutorials) - step by step video and written guides to using the Unity Editor.
  - [Unity Answers](https://answers.unity3d.com/) - here you can ask questions and search answers.
  - [Unity Forums](https://forum.unity3d.com/) - here you can ask questions and search answers.
  - [The Unity Knowledge Base](https://support.unity3d.com/) - a collection of answers to questions posed to Unity's Support teams.
  - [Unity Ads Knowledge Base](https://unityads.unity3d.com/help/index) - a guide to including ads in your game.
  - [Asset Store Help](https://unity3d.com/asset-store/help) - help on Asset Store content sharing.
  - [Issue Tracker](https://issuetracker.unity3d.com/) - issue tracker.

- **Unity Documentation**
  - **Unity User Manual sections**
    - [Working with Unity](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/UnityOverview.html) - A complete introduction to the Unity Editor.
    - [Graphics](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/Graphics.html) - The visual aspects of the Unity Editor including cameras and lighting.
    - [Physics](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/PhysicsSection.html) - Simulation of 3D motion, mass, gravity and collisions.
    - [Networking](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/UNet.html) - How to implement Multiplayer and networking.
    - [Scripting](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/ScriptingSection.html) - Programming your games by using scripting in Unity Editor.
    - [Audio](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/Audio.html) - Audio in the Unity Editor, including clips, sources, listeners, importing and sound settings.
    - [Animation](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/AnimationSection.html) - Animation in the Unity Editor.
    - [UI](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/UIToolkits.html) - User interface toolkits available in the Unity Editor.
    - [Navigation](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/Navigation.html) - Navigation in the Unity Editor, including AI and pathfinding.
    - [Unity Services](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/UnityServices.html)
    - [Virtual Reality](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/VROverview.html)
    - [Contributing to Unity](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/ContributingToUnity.html) - Suggest modifications to some of the Unity Editor's source code.
    - [Platform specific](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/PlatformSpecific.html) - Specific information for the many non-desktop and web platforms you can make projects for with the Unity Editor.
    - [Legacy topics](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/LegacyTopics.html) - Useful if you are maintaining legacy projects.
  - **New**
    - [What's New in 2020.1](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/WhatsNew20201.html)
    - [Upgrading Guide](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/UpgradeGuide20201.html)
  - **Packages**
    - [Working with the Package Manager](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/Packages.html)
    - [Verified packages](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/pack-safe.html)
    - [Preview packages](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/pack-preview.html)
    - [Creating custom packages](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/CustomPackages.html)
  - **Best practice and expert guides**
    - [Best Practice Guides](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/BestPracticeGuides.html)
    - [Expert Guides](file:///C:/Workspace/Archives/Unity/Documentation/Documentation/en/Manual/ExpertGuides.html)