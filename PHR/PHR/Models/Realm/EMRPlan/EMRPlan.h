//
//  Plan.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSInteger, EMRTagType) {
    EMRTagTypeText,
    EMRTagTypePhoto,
    EMRTagTypePdf
};

@interface EMRPlan : NSObject{
    
}
@property (nonatomic,strong) NSString* tag;
@property (nonatomic,strong) NSString* tagName;
@property (nonatomic,strong) NSString* tagContent;
@property (nonatomic,strong) NSString* confirmDate;
@property (nonatomic,strong) NSString* tagUrl;
@property (nonatomic, assign) BOOL isTag;
@property (nonatomic, assign) EMRTagType tagType;
@property (nonatomic,strong) NSArray *arrayERM;

- (instancetype)initWithTag:(NSString*)tag permission:(NSString*)permission andArray:(NSArray*)array;
//- (NSString*)getTagName;
//- (NSString*)getTagContent;
@end
