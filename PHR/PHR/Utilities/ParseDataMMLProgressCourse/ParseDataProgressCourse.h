//
//  ParseDataProgressCourse.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 12/1/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface ParseDataProgressCourse : NSObject

+ (NSString*)replaceWrongXMLData:(NSString*)inputString;
+ (NSArray*)getProgressCourseModule:(NSArray*)inputArray;
+ (NSMutableArray*)getProgressCourseModuleOrderList:(NSMutableArray*)inputArray;

@end
