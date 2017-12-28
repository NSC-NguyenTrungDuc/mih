//
//  RatingBar.h
//  PHR
//
//  Created by BillyMobile on 5/31/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@class RatingBar;
@protocol RatingDelegate
@optional
-(void) setRating:(NSInteger)rating isHuman:(BOOL) isHuman;
@end

@interface RatingBar : UIView
@property (nonatomic,assign) NSInteger starNumber;


@property (nonatomic,strong) UIColor *viewColor;


@property (nonatomic,assign) BOOL enable;


@property (nonatomic, assign) id<RatingDelegate>  delegate;
@end
