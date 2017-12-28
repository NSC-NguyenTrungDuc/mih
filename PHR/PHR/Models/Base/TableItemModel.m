//
//  TableItemModel.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TableItemModel.h"

@implementation TableItemModel

- (instancetype)initWithImagePath:(NSString*)imagePath andTitle:(NSString*)title { 
    if (self = [super init]) {
        self.imagePath = imagePath;
        self.title = title;
    }
    return self;
}

@end
