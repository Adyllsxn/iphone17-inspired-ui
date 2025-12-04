import { NAVBAR } from "@/constants/navBarConstant.js";

export default function Header() {
  return (
    <header className="fixed top-0 w-full bg-black/80 backdrop-blur-md z-50">
      <div className="max-w-7xl mx-auto px-6 py-4 flex items-center justify-center gap-8">
        {NAVBAR.links.map((link, index) => (
          <a
            key={index}
            href={`#${link}`}
            className="hover:text-gray-300"
          >
            {link}
          </a>
        ))}
        <button className="bg-blue-600 hover:bg-blue-700 px-5 py-2 rounded-full">
          {NAVBAR.button}
        </button>
      </div>
    </header>
  );
}
