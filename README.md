AspNetMvcUnityExtensions
========================

These codes are based on a project from codeplex, http://unitymvc3.codeplex.com/. I was seeking for a dependency injection container solution for Asp.Net MVC and endup finding the UnityMvc3 project. However the PreApplicationStartMethod was on the same project with the DependencyResolver modification. So I needed to seperate it. 

This project is tightly coupled with Microsoft Unity. And must be abstracted in the further releases. If the abstraction is done, then Castle Windsor, NInject or any other IoC container would be implemented.

How to use?
-------------

You may have two choices for using them

1. Using the PreApplicationStartMethod assembly attribute;

If you just add AspNetMvcUnityExtensions.AspNetStarter assembly to your project everything will be implemented just before the call of your Application_Start() method of your Global.asax. Then you may start registering your components.

2. Initializing the Resolver Manually;

Second option is to implement the resolver manually like,

    DependencyResolver.SetResolver(new UnityDependencyResolver(CurrentContainer));
    DynamicModuleUtility.RegisterModule(typeof(RequestLifetimeHttpModule));

CurrentContainer is your instance of implementation for IUnityContainer. 

Registering the components
---------------------------

For registering the components to your container you may choose to registering via the container instance you used for instantiating the UnityDependencyResolver. The default implementation should like the code block down;

    DependencyInitializer.CurrentContainer.RegisterType<IFoo, Foo>();

