//
//  PairTabBar.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PairTabBarItem : NSObject
@property (assign,nonatomic) UIImage *image;
@property (assign,nonatomic) NSString *title;

- (instancetype)initWithTitle:(NSString*)title andImage:(UIImage*)image;
@end

@class PairTabBar;
@protocol PairTabBarDelegate
- (void)pairButtonDelegate:(PairTabBar*)pair andSelectedIndex:(NSInteger)index;
@end

@interface PairTabBar : UIView
@property (nonatomic,strong) NSArray<PairTabBarItem *> *items;
- (void)setItem:(NSString*)title and:(NSArray<PairTabBarItem *>*)items;
@end

