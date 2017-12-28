//
//  PHRDateSlider.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/4/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRDateSlider.h"

@implementation PHRDateSlider {
  int scrollViewHeight;

  int numberOfDay;
  //Label
  int distanceValue;
  int maxValue;
  BOOL isScrollToPosition;
  float screenWidth;
  int defaultIndex;
  CGFloat labelWidth;
  CGFloat labelHeight;
  CGFloat labelMarginBottom;
  UIView *viewHighlight;
  int posX;
  CGFloat posY;
  UILabel *labelDay;
}

- (void)initialize:(id)delegate {
  isScrollToPosition = false;
  _delegate = delegate;
  [self initSlider];
  [self scrollToPosition:defaultIndex isAnimate:NO];
}

- (void)initSlider {
  numberOfDay = 30;
  distanceValue = 10;
  labelWidth = 80;
  labelHeight = 30;
  labelMarginBottom = 15;
  defaultIndex = 2;
  posY = self.bounds.size.height / 2 - labelHeight / 2 - labelMarginBottom;
  screenWidth = CGRectGetWidth([[UIScreen mainScreen] bounds]);
  
  viewHighlight = [[UIView alloc] initWithFrame:CGRectMake(screenWidth / 2 - labelWidth / 2, posY / 2 + 5, labelWidth, labelHeight * 3)];
  [viewHighlight.layer setBorderColor:[UIColor colorWithRed:59./255. green:167./255. blue:222./255. alpha:1].CGColor];
  viewHighlight.layer.cornerRadius = 5.0;
  viewHighlight.backgroundColor = [UIColor colorWithRed:237./255. green:249./255. blue:253./255. alpha:1];
  [viewHighlight.layer setBorderWidth:3.5];
  [self addSubview:viewHighlight];

  
  labelDay = [[UILabel alloc] initWithFrame:CGRectMake(viewHighlight.frame.origin.x, viewHighlight.frame.origin.y + 20, viewHighlight.frame.size.width, viewHighlight.frame.size.height)];
  labelDay.font = [FontUtils aileronRegularWithSize:16];
  labelDay.text = kLocalizedString(kDays);
  labelDay.backgroundColor = [UIColor clearColor];
  labelDay.textAlignment = NSTextAlignmentCenter;
  [self addSubview:labelDay];
  
  
  self.scrollView = [[UIScrollView alloc] initWithFrame:CGRectMake(0, 0, screenWidth, self.frame.size.height)];
  self.scrollView.delegate = self;
  [self addSubview:self.scrollView];
  
  
  UIView *viewAlpha = [[UIView alloc] initWithFrame:CGRectMake(0, 0, viewHighlight.frame.origin.x, self.frame.size.height)];
  viewAlpha.backgroundColor = [[UIColor whiteColor] colorWithAlphaComponent:0.7];
  viewAlpha.userInteractionEnabled = false;
  [self addSubview:viewAlpha];
  
  UIView *viewAlphaRight = [[UIView alloc] initWithFrame:CGRectMake(viewHighlight.frame.origin.x + labelWidth, 0, screenWidth, self.frame.size.height)];
  viewAlphaRight.backgroundColor = [[UIColor whiteColor] colorWithAlphaComponent:0.7];
  viewAlphaRight.userInteractionEnabled = false;
  [self addSubview:viewAlphaRight];

  posX = screenWidth / 2 - labelWidth / 2;
  scrollViewHeight = self.scrollView.frame.size.height;
  
  [self drawSlider];
}

- (void)drawSlider {
  
  for (int i = 0; i < numberOfDay; i++) {
    
    [self addLabel:i];
    if (i == numberOfDay - 1) {
      posX += screenWidth / 2 - labelWidth / 2;
    }
  }
  [self.scrollView setShowsVerticalScrollIndicator:NO];
  [self.scrollView setShowsHorizontalScrollIndicator:NO];
  self.scrollView.decelerationRate = UIScrollViewDecelerationRateNormal;
  self.scrollView.bounces = NO;
  self.scrollView.contentSize = CGSizeMake(posX, self.scrollView.bounds.size.height / 2);
  
}

- (void)addLabel:(NSInteger)index {
  
  UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(posX, posY, labelWidth , labelHeight)];
  label.font = [FontUtils aileronBoldWithSize:22];
  label.text = [NSString stringWithFormat:@"%ld", index + 1];
  label.tag = index;
  label.textAlignment = NSTextAlignmentCenter;
  posX += labelWidth;
  [self.scrollView addSubview:label];
}

- (void)scrollViewDidScroll:(UIScrollView *)scrollView {
  if (_delegate) {
    [_delegate scrollViewDateDidScroll:defaultIndex + 1];
  }
}

-(void)scrollViewDidEndDragging:(UIScrollView *)scrollView willDecelerate:(BOOL)decelerate
{
  if (!decelerate) {
    [self calculateScrollPosition:scrollView isAnimate:YES];
  }
}

- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView {
  [self calculateScrollPosition:scrollView isAnimate:YES];
}

- (void)calculateScrollPosition:(UIScrollView *)scrollView isAnimate:(BOOL)isAnimate {
  int index;
  index = roundf(scrollView.contentOffset.x / labelWidth);
  [self scrollToPosition:roundf(index) isAnimate:isAnimate];
}

- (void)scrollToPosition:(int)index isAnimate:(BOOL)isAnimate {
  defaultIndex = index;
  isScrollToPosition = true;
  float xPos =  index * labelWidth;
  [self.scrollView setContentOffset:CGPointMake(xPos, 0) animated:isAnimate];
  if (index == 0) {
    labelDay.text = kLocalizedString(kDay);
  } else {
    labelDay.text = kLocalizedString(kDays);
  }
}

@end
