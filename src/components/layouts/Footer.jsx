import { SECTIONS, BTNLINKS } from "@/constants/footerConstants.js";

export default function Footer(){
    return(
        <footer className="bg-gray-900 border-t-gray-800">
            <div className="max-w-7xl mx-auto px-6 py-2">
                <div className="grid md:grid-cols-4 gap-8">
                    {SECTIONS.map((section, index)=>(
                        <div key={index}>
                            <h4 className="font-semibold mb-4">{section.title}</h4>
                            <ul className="space-y-2 text-sm text-gray-400 mb-4">
                                {section.links.map((link, linkIndex) =>(
                                    <li key={linkIndex}>
                                        <a href="#" className="hover:text-white cursor-pointer">{link}</a>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    ))}
                </div>

                <div className="border-t border-gray-800 pt-6">
                    <div className="flex flex-col md:flex-row justify-between items-center gap-4">
                        <p className="text-md text-gray-500 text-center">Copyright &copy; 2025 Apple Inc. Todos direitos reservados.</p>
                        <div className="flex gap-6 text-gray-400">
                            {BTNLINKS.map((link, index) =>(
                                <a href="#" key={index} className="hover:text-white text-white">{link}</a>
                            ))}
                        </div>
                    </div>
                    <p className="text-xs text-gray-500 my-6">Site Criado para fins educacionais</p>
                </div>
            </div>
        </footer>
    )
}