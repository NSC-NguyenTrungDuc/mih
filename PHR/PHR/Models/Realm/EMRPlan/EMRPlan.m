//
//  Plan.m
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "EMRPlan.h"
#import "EMRTag.h"

@implementation EMRPlan

- (instancetype)initWithTag:(NSString*)tag permission:(NSString*)permission andArray:(NSArray*)array {
    if(self = [self init]){
      
        self.tag = tag;
        self.arrayERM = array;
        self.tagName = [self getTagNameByArrayERM:[permission intValue]];
        self.tagContent = [self getTagContent];
    }
    return self;
}

- (NSString*)getTagNameByArrayERM:(int)permission {
    for (int i = 0; i < self.arrayERM.count; i++) {
        NSArray *array = [self.tag componentsSeparatedByString:@"#"];
        NSString *realTag = @"";
        if (array.count > 1) {
            realTag = [array objectAtIndex:1];
        }
        EMRTag *emrTag = [self.arrayERM objectAtIndex:i];
        if ([self.tag containsString:@"$IMG$"]) {
            _isTag = NO;
            self.tagType = EMRTagTypePhoto;
        }
        else if ([self.tag containsString:@"$PDF$"]) {
            _isTag = NO;
            self.tagType = EMRTagTypePdf;
        }
        else if ([[NSString stringWithFormat:@"%@",[realTag stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]]] isEqualToString:[NSString stringWithFormat:@"%@",[emrTag.tagCode stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]]]]) {
            _isTag = YES;
          if (permission % 2 == 0) {
            return @"";
          } else {
            return emrTag.tagName;
          }
        }
    }
    return @"";
}



- (NSString*)getTagContent{
    NSString *string = @"";
    if ([self.tag containsString:@"$IMG$"] || [self.tag containsString:@"$PDF$"]) {
        string = [[self.tag componentsSeparatedByString:@"$"] objectAtIndex:[self.tag componentsSeparatedByString:@"$"].count-1];
    } else {
        string = [[self.tag componentsSeparatedByString:@"#"] objectAtIndex:[self.tag componentsSeparatedByString:@"#"].count-1];
    }
    return [[string stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]] componentsSeparatedByString:@"\\"].lastObject;
}




@end