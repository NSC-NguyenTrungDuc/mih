//
//  UIView+Extension.m
//  PHR
//
//  Created by DEV-MinhNN on 10/3/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "UIView+Extension.h"

@implementation UIView (Extension) 

- (void)setStyleRegularToViewWithAlpha:(float)alpha {
    [self setBackgroundColor:PHR_COLOR_GRAY];
    [self setAlpha:alpha];
}

- (void)setStyleRegularToViewWithColor:(UIColor *)color {
    [self setBackgroundColor:color];
    [self setAlpha:0.5];
}

- (void)drawDashedLine:(UIColor*)color {
    //border definitions
    CGFloat cornerRadius = 0;
    CGFloat borderWidth = 1;
    int dashPattern1 = 2;
    int dashPattern2 = 2;
    UIColor *lineColor = color;
    
    //drawing
    CGRect frame = self.bounds;
    
    CAShapeLayer *_shapeLayer = [CAShapeLayer layer];
    
    //creating a path
    CGMutablePathRef path = CGPathCreateMutable();
    
    //drawing a border around a view
    CGPathMoveToPoint(path, NULL, frame.origin.x / 2 + 0.5, 1);
    CGPathAddLineToPoint(path, NULL, frame.origin.x / 2 + 0.5, frame.size.height - 1);
    
    //path is set as the _shapeLayer object's path
    _shapeLayer.path = path;
    CGPathRelease(path);
    
    _shapeLayer.backgroundColor = [[UIColor clearColor] CGColor];
    _shapeLayer.frame = frame;
    _shapeLayer.masksToBounds = NO;
    [_shapeLayer setValue:[NSNumber numberWithBool:NO] forKey:@"isCircle"];
    _shapeLayer.fillColor = [[UIColor clearColor] CGColor];
    _shapeLayer.strokeColor = [lineColor CGColor];
    _shapeLayer.lineWidth = borderWidth;
    _shapeLayer.lineDashPattern = [NSArray arrayWithObjects:[NSNumber numberWithInt:dashPattern1], [NSNumber numberWithInt:dashPattern2], nil];
    _shapeLayer.lineCap = kCALineCapRound;
    
    //_shapeLayer is added as a sublayer of the view, the border is visible
    [self.layer addSublayer:_shapeLayer];
    self.layer.cornerRadius = cornerRadius;
}



@end
