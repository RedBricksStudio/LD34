// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */

using System;
namespace AssemblyCSharp
{
	public interface I_ResourceManager
	{
		void setMax(float amount);		
		void setTo(float amount);
		void increaseIn (float amount);
		void decreaseIn (float amount);

		float getCurValue();
		float getMaxValue();
	}
}

