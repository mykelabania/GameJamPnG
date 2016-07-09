﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public static Player Instance;

	public GameObject goPlayer;
	public Rigidbody rgdPlayer;
	public Grid grid;
	public Node currentNode;
	public DIRECTIONS currentDirection;

	public bool isMoving;
	public float speed;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		SwipeControls.Swipe += PlayerDirection;
//		currentNode = grid.NodeFromWorldPoint(goPlayer.transform.position);
//		goPlayer.transform.position = currentNode.worldPosition;
//		Debug.Log(goPlayer.transform.position);
		MovePlayer(currentDirection);
	}

	// Update is called once per frame
	void Update () {
	
		if(isMoving){
//			MovePlayer(currentDirection);
		}
	}
	public void PlayerDirection(DIRECTIONS direction){
		FacePlayer(direction);
	}
	public void FacePlayer(DIRECTIONS direction){
//		if(!isMoving && direction == currentDirection){
//			return;
//		}
		currentDirection = direction;
		goPlayer.transform.rotation = Quaternion.identity;
		if(direction == DIRECTIONS.LEFT){
			goPlayer.transform.Rotate(new Vector3(0f,0f,180f));
		}
		if(direction == DIRECTIONS.RIGHT){
			goPlayer.transform.Rotate(new Vector3(0f,0f,0f));

		}
		if(direction == DIRECTIONS.UP){
			goPlayer.transform.Rotate(new Vector3(0f,0f,90f));

		}
		if(direction == DIRECTIONS.DOWN){
			goPlayer.transform.Rotate(new Vector3(0f,0f,-90f));

		}
//		isMoving = true;
		MovePlayer(direction);
	}
	public void MovePlayer(DIRECTIONS direction){
		rgdPlayer.velocity = Vector3.zero;
		if(direction == DIRECTIONS.LEFT){
			rgdPlayer.AddForce (Vector3.left * speed, ForceMode.Force);
		}
		if(direction == DIRECTIONS.RIGHT){
			rgdPlayer.AddForce (Vector3.right * speed, ForceMode.Force);

		}
		if(direction == DIRECTIONS.UP){
			rgdPlayer.AddForce (Vector3.up * speed, ForceMode.Force);

		}
		if(direction == DIRECTIONS.DOWN){
			rgdPlayer.AddForce (Vector3.down * speed, ForceMode.Force);

		}
	}
	public void MovePlayer(){
		List<Node> neighbors = grid.GetNeighbours(currentNode);
		if(currentDirection == DIRECTIONS.LEFT){
			goPlayer.GetComponent<TweenPosition>().from = currentNode.worldPosition;
			goPlayer.GetComponent<TweenPosition>().to = neighbors[1].worldPosition;
			goPlayer.GetComponent<TweenPosition>().ResetToBeginning();

			goPlayer.GetComponent<TweenPosition>().PlayForward();
//			goPlayer.transform.position = neighbors[1].worldPosition;
			currentNode = neighbors[1];
			return;

		}
		if(currentDirection == DIRECTIONS.RIGHT){
			goPlayer.GetComponent<TweenPosition>().from = currentNode.worldPosition;
			goPlayer.GetComponent<TweenPosition>().to = neighbors[6].worldPosition;
			goPlayer.GetComponent<TweenPosition>().ResetToBeginning();

			goPlayer.GetComponent<TweenPosition>().PlayForward();
//			goPlayer.transform.position = neighbors[6].worldPosition;
			currentNode = neighbors[6];
			return;

		}
		if(currentDirection == DIRECTIONS.UP){
			goPlayer.GetComponent<TweenPosition>().from = currentNode.worldPosition;
			goPlayer.GetComponent<TweenPosition>().to = neighbors[4].worldPosition;
			goPlayer.GetComponent<TweenPosition>().ResetToBeginning();

			goPlayer.GetComponent<TweenPosition>().PlayForward();
//			goPlayer.transform.position = neighbors[4].worldPosition;
			currentNode = neighbors[4];
			return;

		}
		if(currentDirection == DIRECTIONS.DOWN){
			goPlayer.GetComponent<TweenPosition>().from = currentNode.worldPosition;
			goPlayer.GetComponent<TweenPosition>().to = neighbors[3].worldPosition;
			goPlayer.GetComponent<TweenPosition>().ResetToBeginning();

			goPlayer.GetComponent<TweenPosition>().PlayForward();
//			goPlayer.transform.position = neighbors[3].worldPosition;
			currentNode = neighbors[3];
			return;

		}

	}
	public void StopMoving(){
		isMoving = false;
		Debug.Log(goPlayer.transform.position);
//		currentNode = grid.NodeFromWorldPoint(goPlayer.transform.position);
//		goPlayer.GetComponent<TweenPosition>().from = goPlayer.transform.position;
//		goPlayer.GetComponent<TweenPosition>().to = currentNode.worldPosition;
//		goPlayer.GetComponent<TweenPosition>().ResetToBeginning();
//		goPlayer.GetComponent<TweenPosition>().PlayForward();
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "wall"){
			Debug.Log("WALL");
//			StopMoving();
		}
	}
}
