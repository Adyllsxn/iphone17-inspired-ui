import { COLORS } from "@/constants/colorsConstants.js";
import { MODELS } from "@/constants/modelsConstants.js";
import { useState } from "react";

export default function Colors(){

    const[selectedColor, setSelectedColor]= useState('blue');

    return(
        <section id="Cores" className="bg-black py-20 px-8">
            <div className="max-w-7xl mx-auto">
                
                <div className="text-center mb-16">
                    <h2 className="text-5xl md:text-6xl font-bold mb-4">Escolha sua cor</h2>
                    <p className="text-xl text-gray-400">Quatro acabamento em titânio lindos</p>
                </div>

                <div className="flex justify-center mb-12">
                    <div className="relative w-full max-w-3xl">
                        <div className="relative flex items-center justify-center min-h-[500px]">
                            <img src={COLORS.find(color => color.id === selectedColor).image}           alt="iphone 17" className="max-w-full max-h-[600px] mx-auto" />
                        </div>
                        <div className="absolute bottom-8 left-0 right-0 text-center">
                            <div className="px-8 py-4 rounded-full backdrop-blur-md bg-black/40 inline-block">
                                <h3 className="text-2xl font-semibold">{COLORS.find(color => color.id === selectedColor).name}</h3>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="flex justify-center items-center gap-8">
                    {COLORS.map(color => (
                        <button 
                            key={color.id} 
                            onClick={ () => setSelectedColor(color.id)}
                            className={`relative transition-all duration-300 cursor-pointer hover:scale-125`}>
                            <div className={`w-14 h-14 rounded-full border-2 ${color.colorClass} ${selectedColor === color.id ? `border-white` : `border-gray-500`}`}></div>
                        </button>
                    ))}
                </div>
                
                <div className="grid grid-cols-2 gap-8 mt-20">
                    {MODELS.map((model, index) => (
                        <div key={index} className="bg-gradient-to-br from-gray-900 to-transparent rounded-3xl p-8 border border-gray-900">
                            <div className="text-4xl mb-4">📱</div>
                            <h3 className="text-2xl font-bold mb-3">{model.name}</h3>
                            <p className="text-gray-400 mb-4">{model.screen}</p>
                            <ul className="space-y-2 text-gray-300">
                                <li>{model.storage}</li>
                                <li>{model.battery}</li>
                                <li>{model.weight}</li>
                            </ul>
                        </div>
                    ))}
                </div>

                <div className="text-center mt-16">
                    <button className="bg-blue-700 hover:bg-blue-800 text-white px-12 py-4 rounded-full text-lg font-medium transition-all duration-300 mb-7 hover:scale-105 shadow-md shadow-blue-500/50 cursor-pointer">
                        Compre agora á  partir de 1.950.000 Kz
                    </button>
                    <p>Ou em até 12x de 875.000 Kz sem juros</p>
                </div>
                
            </div>
        </section>
    )
}