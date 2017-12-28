//
//  TriangleView.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "TriangleView.h"

@implementation TriangleView {
    float alpha;
}



-(void)drawRect:(CGRect)rect
{
    
    if (_isDown) {
        CGContextRef ctx = UIGraphicsGetCurrentContext();
        
        CGContextBeginPath(ctx);
        CGContextMoveToPoint   (ctx, CGRectGetMinX(rect), CGRectGetMinY(rect));// top left
        CGContextAddLineToPoint(ctx, CGRectGetMidX(rect), CGRectGetMaxY(rect));// mid right
        CGContextAddLineToPoint(ctx, CGRectGetMaxX(rect), CGRectGetMinY(rect));// bottom left
        CGContextClosePath(ctx);
        
        CGContextSetRGBFillColor(ctx, [[self.arrayRGB objectAtIndex:0] floatValue] / 255.0, [[self.arrayRGB objectAtIndex:1] floatValue]/ 255.0, [[self.arrayRGB objectAtIndex:2] floatValue]/ 255.0, 1);
        CGContextFillPath(ctx);
    } else {
        CGContextRef ctx = UIGraphicsGetCurrentContext();
        
        CGContextBeginPath(ctx);
        CGContextMoveToPoint   (ctx, CGRectGetMinX(rect), CGRectGetMaxY(rect));// top left
        CGContextAddLineToPoint(ctx, CGRectGetMidX(rect), CGRectGetMinY(rect));// mid right
        CGContextAddLineToPoint(ctx, CGRectGetMaxX(rect), CGRectGetMaxY(rect));// bottom left
        CGContextClosePath(ctx);
        alpha= 0.7;
        if(self.arrayRGB.count == 4) {
            alpha = [[self.arrayRGB objectAtIndex:3] floatValue];
        }
        CGContextSetRGBFillColor(ctx, [[self.arrayRGB objectAtIndex:0] floatValue] / 255.0, [[self.arrayRGB objectAtIndex:1] floatValue]/ 255.0, [[self.arrayRGB objectAtIndex:2] floatValue]/ 255.0, alpha);
        CGContextFillPath(ctx);
    }

    
}


@end
