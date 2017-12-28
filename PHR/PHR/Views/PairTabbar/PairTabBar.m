//
//  PairTabBar.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PairTabBar.h"
#import <PureLayout/PureLayout.h>

@implementation PairTabBarItem
- (instancetype)initWithTitle:(NSString*)title andImage:(UIImage*)image {
    self = [super init];
    if (self != nil){
        self.title = title;
        self.image = image;
    }
    return self;
}
@end

@implementation PairTabBar

/*
 // Only override drawRect: if you perform custom drawing.
 // An empty implementation adversely affects performance during animation.
 - (void)drawRect:(CGRect)rect {
 // Drawing code
 }
 */

- (instancetype)initWithFrame:(CGRect)frame {
    if (self = [super initWithFrame:frame]) {
        [self initContent];
    }
    return self;
}

- (instancetype)initWithCoder:(NSCoder *)aDecoder {
    if (self = [super initWithCoder:aDecoder]) {
        [self initContent];
    }
    return self;
}

- (void) initContent {
    
}

- (void)setItems:(NSArray<PairTabBarItem *> *)items {
    _items = items;
    int i = 0;
    CGSize itemSize = CGSizeMake(self.bounds.size.width / _items.count, [UIScreen mainScreen].bounds.size.height);
    for (PairTabBarItem* obj in _items) {
        CGRect rect = CGRectMake(i * itemSize.width, 0, itemSize.width, itemSize.height);
        UIView * tabItem = [[UIView alloc] initWithFrame:rect];
        [self makeTabItem:tabItem pairItem:obj];
        [self addSubview:tabItem];
        [tabItem autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset: i * itemSize.width];
        [tabItem autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset: self.bounds.size.width - ( i + 1) * itemSize.width];
        [tabItem autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0.0];
        [tabItem autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0.0];
        if (i % 2 == 0){
            tabItem.backgroundColor = [UIColor blueColor];
        } else {
            tabItem.backgroundColor = [UIColor greenColor];
        }
        i++;
    }
}

- (void)setItem:(NSString*)title and:(NSArray<PairTabBarItem *>*)items {

}

- (void)makeTabItem:(UIView*)view pairItem:(PairTabBarItem*)pairItem {
    if (pairItem.title && ![pairItem.title isEqualToString:@""]) {
        
        if (pairItem.image) {
            CGRect rectImage = CGRectMake(0, 0, view.frame.size.width / 2, view.frame.size.height);
            CGRect rectLabel = CGRectMake(view.frame.size.width / 2, 0, view.frame.size.width / 2, view.frame.size.height);
            UIImageView *imageView = [[UIImageView alloc] initWithFrame:rectImage];
            imageView.image = pairItem.image;
            UILabel *label = [[UILabel alloc] initWithFrame:rectLabel];
            label.text = pairItem.title;
            label.textColor = [UIColor yellowColor];
            label.textAlignment = NSTextAlignmentCenter;
            [view addSubview:imageView];
            [view addSubview:label];
            [label autoPinEdgeToSuperviewEdge:ALEdgeLeft withInset:imageView.frame.size.width];
            [label autoPinEdgeToSuperviewEdge:ALEdgeRight withInset:0.0];
            [label autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0.0];
            [label autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0.0];
        } else {
            UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(0, 0, view.frame.size.width, view.frame.size.height)];
            label.text = pairItem.title;
            label.textColor = [UIColor redColor];
            label.backgroundColor = [UIColor clearColor];
            label.textAlignment = NSTextAlignmentCenter;
            label.font = [UIFont fontWithName:label.font.fontName size:10.0];
             [view addSubview:label];
            label.layer.borderWidth = 1.0;
            label.layer.borderColor = [UIColor blackColor].CGColor;
            [label autoPinEdgeToSuperviewEdge:ALEdgeLeft withInset:0.0];
            [label autoPinEdgeToSuperviewEdge:ALEdgeRight withInset:0.0];
            [label autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0.0];
            [label autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0.0];
        }
    }
}
@end
