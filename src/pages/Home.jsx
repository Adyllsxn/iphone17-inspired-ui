import Hero from "@/components/sections/Hero";
import Intro from "@/components/sections/Intro";
import Highlights from "@/components/sections/Highlights";
import Colors from "@/components/sections/Colors";

export default function Home() {
  return (
    <div>
      <Hero />
      <Intro />
      <Highlights/>
      <Colors/>
    </div>
  );
}
