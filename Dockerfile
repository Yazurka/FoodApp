FROM mono:4.6.0
ADD FoodBackend FoodBackend
WORKDIR FoodBackend
RUN nuget restore Food.Server/packages.config -SolutionDirectory ..
RUN nuget restore Food.Server.WebApi/packages.config -SolutionDirectory ..
RUN nuget restore Food.Server.Selfhost/packages.config -SolutionDirectory ..
RUN xbuild FoodBackend.sln

CMD mono Food.Server.Selfhost/bin/Debug/Food.Server.Selfhost.exe
