using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProvider {

	/// <summary>
	/// Common Items Adding Here 
	/// </summary>

	public static ArrayList GetCharactersBodyDataList() {
		ArrayList list = new ArrayList ();

		list.Add (new BaseItem("1", "Character/Body", "character_1",false,0));
		list.Add (new BaseItem("2", "Character/Body", "character_2",false,0));
		list.Add (new BaseItem("3", "Character/Body", "character_3",false,0));

		return list;
	}


	public static ArrayList GetCharactersLipsDataList() {
		ArrayList list = new ArrayList ();

		list.Add (new BaseItem("1", "Characters/Lips", "lip_1",false,0));
		list.Add (new BaseItem("2", "Characters/Lips", "lip_2",false,0));
		list.Add (new BaseItem("3", "Characters/Lips", "lip_3",false,0));

		return list;
	}

	/// <summary>
	/// Spa Scene Items Adding Here 
	/// </summary>

	public static ArrayList GetCharacterClothDataList() {
		ArrayList list = new ArrayList ();
		list.Add (new BaseItem("1", "SpaView/Clothes", "cloth_1",false,0));
		list.Add (new BaseItem("2", "SpaView/Clothes","cloth_2",false,0));
		list.Add (new BaseItem("3", "SpaView/Clothes", "cloth_3",false,0));
		return list;
	}


	/// <summary>
	/// Dressup Scene Items Adding Here 
	/// </summary>

	public static ArrayList GetDressDataList() {
		ArrayList list = new ArrayList ();
		list.Add (new BaseItem("1", "DressUpView/WeddingDress", "weddingdress_1", false, 0));
		list.Add (new BaseItem("2", "DressUpView/WeddingDress", "weddingdress_2", false, 0));
		list.Add (new BaseItem("3", "DressUpView/WeddingDress", "weddingdress_3", false, 0));
		list.Add (new BaseItem("4", "DressUpView/WeddingDress", "weddingdress_4", false, 0));
		list.Add (new BaseItem("5", "DressUpView/WeddingDress", "weddingdress_5", false, 0));
		list.Add (new BaseItem("6", "DressUpView/WeddingDress", "weddingdress_6", false, 0));
		list.Add (new BaseItem("7", "DressUpView/WeddingDress", "weddingdress_7", false, 0));
		list.Add (new BaseItem("8", "DressUpView/WeddingDress", "weddingdress_8", false, 0));
        list.Add (new BaseItem("9", "DressUpView/WeddingDress", "weddingdress_9", false, 0));
        list.Add (new BaseItem("10", "DressUpView/WeddingDress", "weddingdress_10", false, 0));
        list.Add (new BaseItem("11", "DressUpView/WeddingDress", "weddingdress_11", false, 0));
        return list;
	}

    public static ArrayList GetVeilDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/WeddingVeil", "veil_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/WeddingVeil", "veil_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/WeddingVeil", "veil_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/WeddingVeil", "veil_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/WeddingVeil", "veil_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/WeddingVeil", "veil_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/WeddingVeil", "veil_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/WeddingVeil", "veil_8", false, 0));
        return list;
    }

    public static ArrayList GetWeddingEarringsDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/WeddingEarrings", "Earring_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/WeddingEarrings", "Earring_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/WeddingEarrings", "Earring_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/WeddingEarrings", "Earring_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/WeddingEarrings", "Earring_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/WeddingEarrings", "Earring_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/WeddingEarrings", "Earring_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/WeddingEarrings", "Earring_8", false, 0));
        return list;
    }

    public static ArrayList GetFashionEarringsDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/FashionEarrings", "Earring_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/FashionEarrings", "Earring_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/FashionEarrings", "Earring_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/FashionEarrings", "Earring_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/FashionEarrings", "Earring_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/FashionEarrings", "Earring_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/FashionEarrings", "Earring_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/FashionEarrings", "Earring_8", false, 0));
        return list;
    }

    public static ArrayList GetFlowersDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/WeddingFlowers", "flower_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/WeddingFlowers", "flower_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/WeddingFlowers", "flower_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/WeddingFlowers", "flower_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/WeddingFlowers", "flower_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/WeddingFlowers", "flower_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/WeddingFlowers", "flower_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/WeddingFlowers", "flower_8", false, 0));
        return list;
    }

    public static ArrayList GetNecklaceDataList() {
		ArrayList list = new ArrayList ();
		list.Add (new BaseItem("1", "DressUpView/WeddingNecklace", "necklace_1", false, 0));
		list.Add (new BaseItem("2", "DressUpView/WeddingNecklace", "necklace_2", false, 0));
		list.Add (new BaseItem("3", "DressUpView/WeddingNecklace", "necklace_3", false, 0));
		list.Add (new BaseItem("4", "DressUpView/WeddingNecklace", "necklace_4", false, 0));
		list.Add (new BaseItem("5", "DressUpView/WeddingNecklace", "necklace_5", false, 0));
		list.Add (new BaseItem("6", "DressUpView/WeddingNecklace", "necklace_6", false, 0));
		list.Add (new BaseItem("7", "DressUpView/WeddingNecklace", "necklace_7", false, 0));
		list.Add (new BaseItem("8", "DressUpView/WeddingNecklace", "necklace_8", false, 0));
		
		return list;
	}

    public static ArrayList GetHeadWearDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/WeddingHeadwear", "headwear_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/WeddingHeadwear", "headwear_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/WeddingHeadwear", "headwear_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/WeddingHeadwear", "headwear_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/WeddingHeadwear", "headwear_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/WeddingHeadwear", "headwear_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/WeddingHeadwear", "headwear_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/WeddingHeadwear", "headwear_8", false, 0));

        return list;
    }


    public static ArrayList GetShoesDataList() {
		ArrayList list = new ArrayList ();
		list.Add (new BaseItem("1", "DressUpView/WeddingShoes", "shoes_1", false, 0));
		list.Add (new BaseItem("2", "DressUpView/WeddingShoes", "shoes_2", false, 0));
		list.Add (new BaseItem("3", "DressUpView/WeddingShoes", "shoes_3", false, 0));
		list.Add (new BaseItem("4", "DressUpView/WeddingShoes", "shoes_4", false, 0));
		list.Add (new BaseItem("5", "DressUpView/WeddingShoes", "shoes_5", false, 0));
		list.Add (new BaseItem("6", "DressUpView/WeddingShoes", "shoes_6", false, 0));
		list.Add (new BaseItem("7", "DressUpView/WeddingShoes", "shoes_7", false, 0));
		list.Add (new BaseItem("8", "DressUpView/WeddingShoes", "shoes_8", false, 0));
		
		return list;
	}

    public static ArrayList GetFashionDressDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/FashionDress", "fashiondress_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/FashionDress", "fashiondress_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/FashionDress", "fashiondress_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/FashionDress", "fashiondress_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/FashionDress", "fashiondress_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/FashionDress", "fashiondress_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/FashionDress", "fashiondress_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/FashionDress", "fashiondress_8", false, 0));
        list.Add(new BaseItem("9", "DressUpView/FashionDress", "fashiondress_9", false, 0));
        list.Add(new BaseItem("10", "DressUpView/FashionDress", "fashiondress_10", false, 0));
        list.Add(new BaseItem("11", "DressUpView/FashionDress", "fashiondress_11", false, 0));
        list.Add(new BaseItem("12", "DressUpView/FashionDress", "fashiondress_12", false, 0));
        return list;
    }

    public static ArrayList GetFashionBagsDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/FashionBags", "bag_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/FashionBags", "bag_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/FashionBags", "bag_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/FashionBags", "bag_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/FashionBags", "bag_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/FashionBags", "bag_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/FashionBags", "bag_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/FashionBags", "bag_8", false, 0));
        return list;
    }

    public static ArrayList GetFashionBracletDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/FashionBraclet", "braclet_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/FashionBraclet", "braclet_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/FashionBraclet", "braclet_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/FashionBraclet", "braclet_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/FashionBraclet", "braclet_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/FashionBraclet", "braclet_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/FashionBraclet", "braclet_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/FashionBraclet", "braclet_8", false, 0));
        return list;
    }

    public static ArrayList GetFashionShoesDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/FashionShoes", "shoes_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/FashionShoes", "shoes_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/FashionShoes", "shoes_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/FashionShoes", "shoes_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/FashionShoes", "shoes_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/FashionShoes", "shoes_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/FashionShoes", "shoes_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/FashionShoes", "shoes_8", false, 0));
        return list;
    }

    public static ArrayList GetFashionNecklaceDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "DressUpView/FashionNecklace", "necklace_1", false, 0));
        list.Add(new BaseItem("2", "DressUpView/FashionNecklace", "necklace_2", false, 0));
        list.Add(new BaseItem("3", "DressUpView/FashionNecklace", "necklace_3", false, 0));
        list.Add(new BaseItem("4", "DressUpView/FashionNecklace", "necklace_4", false, 0));
        list.Add(new BaseItem("5", "DressUpView/FashionNecklace", "necklace_5", false, 0));
        list.Add(new BaseItem("6", "DressUpView/FashionNecklace", "necklace_6", false, 0));
        list.Add(new BaseItem("7", "DressUpView/FashionNecklace", "necklace_7", false, 0));
        list.Add(new BaseItem("8", "DressUpView/FashionNecklace", "necklace_8", false, 0));
        return list;
    }

    /// Makeup Scene Items Adding Here 
    /// </summary>

    public static ArrayList GetMakeUpHairsDataList() {
		ArrayList list = new ArrayList ();
		list.Add (new BaseItem("1", "MakeUpView/Hairs", "hair_1", false, 0));
		list.Add (new BaseItem("2", "MakeUpView/Hairs", "hair_2", false, 0));
		list.Add (new BaseItem("3", "MakeUpView/Hairs", "hair_3", false, 0));
		list.Add (new BaseItem("4", "MakeUpView/Hairs", "hair_4", false, 0));
		list.Add (new BaseItem("5", "MakeUpView/Hairs", "hair_5", false, 0));
		list.Add (new BaseItem("6", "MakeUpView/Hairs", "hair_6", false, 0));
		list.Add (new BaseItem("7", "MakeUpView/Hairs", "hair_7", false, 0));
		list.Add (new BaseItem("8", "MakeUpView/Hairs", "hair_8", false, 0));
		list.Add (new BaseItem("9", "MakeUpView/Hairs", "hair_9", false, 0));
		list.Add (new BaseItem("10", "MakeUpView/Hairs", "hair_10", false, 0));

		return list;
	}

    public static ArrayList GetFashionHairsDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "MakeUpView/FashionHairs", "hair_1", false, 0));
        list.Add(new BaseItem("2", "MakeUpView/FashionHairs", "hair_2", false, 0));
        list.Add(new BaseItem("3", "MakeUpView/FashionHairs", "hair_3", false, 0));
        list.Add(new BaseItem("4", "MakeUpView/FashionHairs", "hair_4", false, 0));
        list.Add(new BaseItem("5", "MakeUpView/FashionHairs", "hair_5", false, 0));
        list.Add(new BaseItem("6", "MakeUpView/FashionHairs", "hair_6", false, 0));
        list.Add(new BaseItem("7", "MakeUpView/FashionHairs", "hair_7", false, 0));
        list.Add(new BaseItem("8", "MakeUpView/FashionHairs", "hair_8", false, 0));
        list.Add(new BaseItem("9", "MakeUpView/FashionHairs", "hair_9", false, 0));
        list.Add(new BaseItem("10", "MakeUpView/FashionHairs", "hair_10", false, 0));

        return list;
    }

    public static ArrayList GetEyeBrowsDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "MakeUpView/EyeBrows", "eyebrow_1", false, 0));
        list.Add(new BaseItem("2", "MakeUpView/EyeBrows", "eyebrow_2", false, 0));
        list.Add(new BaseItem("3", "MakeUpView/EyeBrows", "eyebrow_3", false, 0));
        list.Add(new BaseItem("4", "MakeUpView/EyeBrows", "eyebrow_4", false, 0));
        list.Add(new BaseItem("5", "MakeUpView/EyeBrows", "eyebrow_5", false, 0));
        list.Add(new BaseItem("6", "MakeUpView/EyeBrows", "eyebrow_6", false, 0));
        list.Add(new BaseItem("7", "MakeUpView/EyeBrows", "eyebrow_7", false, 0));
        list.Add(new BaseItem("8", "MakeUpView/EyeBrows", "eyebrow_8", false, 0));
        return list;
    }
    public static ArrayList GetLensDataList() {
		ArrayList list = new ArrayList ();
		list.Add (new BaseItem("1", "MakeUpView/Lens", "lens_1", false, 0));
		list.Add (new BaseItem("2", "MakeUpView/Lens", "lens_2", false, 0));
		list.Add (new BaseItem("3", "MakeUpView/Lens", "lens_3", false, 0));
		list.Add (new BaseItem("4", "MakeUpView/Lens", "lens_4", false, 0));
		list.Add (new BaseItem("5", "MakeUpView/Lens", "lens_5", false, 0));
		list.Add (new BaseItem("6", "MakeUpView/Lens", "lens_6", false, 0));
		list.Add (new BaseItem("7", "MakeUpView/Lens", "lens_7", false, 0));
		list.Add (new BaseItem("8", "MakeUpView/Lens", "lens_8", false, 0));
		list.Add (new BaseItem("9", "MakeUpView/Lens", "lens_9", false, 0));
		list.Add (new BaseItem("10", "MakeUpView/Lens", "lens_10", false, 0));

		return list;
	}

    public static ArrayList GetMakeUpEyeLashesDataList()
    {
        ArrayList list = new ArrayList();
        list.Add(new BaseItem("1", "MakeUpView/EyeLashes", "eyelash_1", false, 0));
        list.Add(new BaseItem("2", "MakeUpView/EyeLashes", "eyelash_2", false, 0));
        list.Add(new BaseItem("3", "MakeUpView/EyeLashes", "eyelash_3", false, 0));
        list.Add(new BaseItem("4", "MakeUpView/EyeLashes", "eyelash_4", false, 0));
        list.Add(new BaseItem("5", "MakeUpView/EyeLashes", "eyelash_5", false, 0));
        list.Add(new BaseItem("6", "MakeUpView/EyeLashes", "eyelash_6", false, 0));
        list.Add(new BaseItem("7", "MakeUpView/EyeLashes", "eyelash_7", false, 0));
        list.Add(new BaseItem("8", "MakeUpView/EyeLashes", "eyelash_8", false, 0));
        list.Add(new BaseItem("9", "MakeUpView/EyeLashes", "eyelash_9", false, 0));
        list.Add(new BaseItem("10", "MakeUpView/EyeLashes","eyelash_10", false, 0));

        return list;
    }


}
