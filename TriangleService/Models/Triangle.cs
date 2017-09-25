using System;
using System.Collections;

namespace TriangleService.Models{
    public class Triangle{
        public Triangle (){
        }

        float[] segments = new float[] { 0.0F, 0.0F, 0.0F };
        public float Segment1 { 
            get{
                return segments[0];
            }
            set{
                segments[0] = value;
            } 
        }

        public float Segment2 { 
            get{
                return segments[1];
            }
            set{
                segments[1] = value;
            }
        }

        public float Segment3 { 
            get{
                return segments[2];
            }
            set{
                segments[2] = value;
            }
        }

        public TriangleTypes Type {
            get{
                float sumSegments = 0.0F;
                float priorSegment = 0.0F;
                TriangleTypes type = TriangleTypes.UNKNOWN;

                //Always sort to check for invalid triangle from segment lengths
                Array.Sort(segments);

                for(int x = 0; x < 3; x++ ){ //each(float segment in segments){
                    float segment = segments[x];

                    if(segment == 0.0F){
                        //Dont go any further, invalid triangle
                        type = TriangleTypes.NOT_A_TRIANGLE;
                        break;
                    }
                    else if(segment == priorSegment){
                        //If segments equals prior segment, triangle is at least Isocseles but need to check next side to confirm Equilateral
                        if(type == TriangleTypes.ISOSCELES){
                            type = TriangleTypes.EQUILATERAL;
                            break;
                        }
                        else{
                            type = TriangleTypes.ISOSCELES;
                        }
                    }
                    else if (x == 2){//Need to make decision on last iteration
                        if(segment >= sumSegments){
                            type = TriangleTypes.NOT_A_TRIANGLE;
                            break;
                        }
                        else if(type == 0){//it must be a scalene
                            type = TriangleTypes.SCALENE;
                        }
                        else{
                            //type is already isosceles
                            break;
                        }
                    }

                    sumSegments += segment;
                    priorSegment = segment;
                }

                return type;
            }
        }
    }

    public enum TriangleTypes{
        UNKNOWN,
        EQUILATERAL,
        ISOSCELES,
        SCALENE,
        NOT_A_TRIANGLE
    }
}