/******************************************************************************\
* Copyright (C) 2012-2016 Leap Motion, Inc. All rights reserved.               *
* Leap Motion proprietary and confidential. Not for distribution.              *
* Use subject to the terms of the Leap Motion SDK Agreement available at       *
* https://developer.leapmotion.com/sdk_agreement, or another agreement         *
* between Leap Motion and you, your company or other organization.             *
\******************************************************************************/

namespace Leap
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    
    /**
   * The HandList class represents a list of Hand objects.
   *
   * Get a HandList object by calling Frame::hands().
   *
   * \include HandList_HandList.txt
   *
   * @since 1.0
   */
    
    public class HandList : List<IHand>
    {
        public HandList():base(){}
        public HandList(int initialCapacity):base(initialCapacity){}

        
        /**
     * Returns a list containing hands from the current list of a given hand type by
     * modifying the existing list.
     *
     * \include HandList_handType.txt
     *
    * @returns The list of matching hands from the current list.
     * @since 2.0
     */
        public HandList HandType (bool leftHand)
        {
            return (HandList) this.FindAll (delegate (IHand hand) {
                return hand.IsLeft == leftHand;
            });
        }
        
        
        
        /**
     * Reports whether the list is empty.
     *
     * \include HandList_isEmpty.txt
     *
     * @returns True, if the list has no members.
     * @since 1.0
     */
        public bool IsEmpty {
            get {
                return this.Count == 0;
            } 
        }
        
        /**
     * The member of the list that is farthest to the left within the standard
     * Leap Motion frame of reference (i.e has the smallest X coordinate).
     *
     * \include HandList_leftmost.txt
     *
     * @returns The leftmost hand, or invalid if list is empty.
     * @since 1.0
     */
        public IHand Leftmost {
            get {
                if (this.Count == 0)
                    return Hand.Invalid;

                IHand mostest = null;
                float position = float.MaxValue;

                foreach(IHand hand in this){
                    if(hand.PalmPosition.x <= position){
                        mostest = hand;
                        position = hand.PalmPosition.x;
                    }
                }
                return mostest;
            } 
        }
        
        /**
     * The member of the list that is farthest to the right within the standard
     * Leap Motion frame of reference (i.e has the largest X coordinate).
     *
     * \include HandList_rightmost.txt
     *
     * @returns The rightmost hand, or invalid if list is empty.
     * @since 1.0
     */
        public IHand Rightmost {
            get {
                if (this.Count == 0)
                    return Hand.Invalid;

                IHand mostest = null;
                float position = float.MinValue;

                foreach(IHand hand in this){
                    if(hand.PalmPosition.x >= position){
                        mostest = hand;
                        position = hand.PalmPosition.x;
                    }
                }
                return mostest;
            } 
        }
        
        /**
     * The member of the list that is farthest to the front within the standard
     * Leap Motion frame of reference (i.e has the smallest Z coordinate).
     *
     * \include HandList_frontmost.txt
     *
     * @returns The frontmost hand, or invalid if list is empty.
     * @since 1.0
     */
        public IHand Frontmost {
            get {
                if (this.Count == 0)
                    return Hand.Invalid;

                IHand mostest = null;
                float position = float.MaxValue;

                foreach(IHand hand in this)
                {
                    if(hand.PalmPosition.z <= position){
                        mostest = hand;
                        position = hand.PalmPosition.z;
                    }
                }
                return mostest;
            } 
        }
        
    }
    
}
