import { SPECS } from "@/constants/introConstants.js";

export default function Intro() {

  return (
    <section className="bg-black py-20 px-6">
      
      <div className="max-w-5xl mx-auto text-center">
        <h1 className="text-6xl md:text-8xl font-bold mb-6 ">iPhone 17 Pro</h1>
        <p className="text-2xl md:text-4xl mb-4 text-gradient font-bold">
          Titâbio. Tão forte. Tão leve. Tão Pro
        </p>
        <p className="text-lg md:text-xl text-gray-300 mb-10 max-w-3xl mx-auto">
          O Design mais refinado que já criamos. Titânio de grau aerospacial.
          Chip A18 Pron.Sistema de câmera Pro revolucionãrio.
        </p>
      
      </div>

      <div className="flex flex-col md:flex-row gap-4 justify-center items-center mb-16">
        <button className="bg-blue-600 hover:bg-blue-700 text-white px-8 py-4 rounded-full text-lg font-medium transition-all duration-300 hover:scale-105 shadow-lg shadow-blue-500/50 cursor-pointer">Compre Agora</button>
        <button className="border-2 border-white rounded-full hover:bg-white hover:text-black px-8 py-4 rounded-full text-lg font-medium transition-all duration-300 hover:scale-105 shadow-lg cursor-pointer">Saiba Mais</button>
      </div>

      <div className="grid grid-cols-2 md:grid-cols-4 gap-6 mx-auto max-w-5xl">
        {SPECS.map((spec, index) =>(
          <div key={index} className="bg-gray-900 rounded-2xl p-6 hover:bg-gray-800 transition-all duration-300 hover:scale-105 cursor-pointer">
            <p className={`text-3xl font-bold ${spec.color}`}>{spec.value}</p>
            <p>{spec.label}</p>
          </div>
        ))}
      </div>

    </section>
  );
}
