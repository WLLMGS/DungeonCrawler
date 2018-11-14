using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
	SpawnRoom = 1,
	BasicRoom = 2,
	SpecialRoom = 3
}

public class RoomStats : MonoBehaviour {

	private bool _IsSpecialRoom = false;
	private RoomType _roomtype = RoomType.BasicRoom;

	public bool IsSpecialRoom()
	{
		return _IsSpecialRoom;
	}
	public void SetIsSpecialRoom(bool spec)
	{
		_IsSpecialRoom = spec;
	}

	public RoomType GetRoomType()
	{
		return _roomtype;
	}
	public void SetRoomType(RoomType type)
	{
		_roomtype = type;
	}
}
