//
//  TableItemModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TableItemModel : NSObject

@property (nonatomic, strong) NSString *imagePath;
@property (nonatomic, strong) NSString *title;

- (instancetype)initWithImagePath:(NSString*)imagePath andTitle:(NSString*)title;

@end
