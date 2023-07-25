import TasksCompletionsWrapper from "../components/ui/TasksCompletionsWrapper";
import HomeSubtitle from "../components/ui/HomeSubtitle";
import ProfileCard from "../components/ui/ProfileCard";
import RevenueCard from "../components/ui/RevenueCard";
import ViewAllButton from "../components/ui/ViewAllButton";
import RecentProjects from "../components/ui/RecentProjects";
import Tasks from "../components/ui/Tasks";

function Home(){
    return(<main>
        <article className="container article">
          <HomeSubtitle />
          <section className="home">
            <ProfileCard />
            <TasksCompletionsWrapper />
            <RevenueCard value={2100}/>
          </section>
          {/* 
        - #PROJECTS
      */}
          <section className="projects">
            <RecentProjects />
          </section>
          {/* 
        - #TASKS
      */}
          <section className="tasks">
            <Tasks />
          </section>
        </article>
      </main>
      );
}
export default Home;