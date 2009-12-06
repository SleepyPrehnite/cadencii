package org.kbinani.windows.forms;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Insets;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.font.FontRenderContext;
import java.awt.font.GlyphMetrics;
import java.awt.font.GlyphVector;
import java.awt.geom.Point2D;
import javax.swing.JLabel;

public class BLabel extends JLabel{
    private static final long serialVersionUID = -6416404129933688215L;
    private boolean flg = true;
    private GlyphVector gvtext;

    public BLabel(){
        super();
        addComponentListener( new ComponentAdapter(){
            public void componentResized( ComponentEvent e ){
                flg = true;
                repaint();
            }
        } );
    }
    
    private GlyphVector getWrappedGlyphVector( String str, float wrapping, Font font, FontRenderContext frc ){
        Point2D gmPos = new Point2D.Double(0.0d, 0.0d);
        GlyphVector gv = font.createGlyphVector(frc, str);
        float lineheight = (float)gv.getLogicalBounds().getHeight();
        float xpos = 0.0f;
        float advance = 0.0f;
        int   lineCount = 0;
        GlyphMetrics gm;
        for( int i = 0; i < gv.getNumGlyphs(); i++ ){
            gm = gv.getGlyphMetrics( i );
            advance = gm.getAdvance();
            if( xpos < wrapping && wrapping <= xpos + advance ){
                lineCount++;
                xpos = 0.0f;
            }
            gmPos.setLocation( xpos, lineheight * lineCount );
            gv.setGlyphPosition( i, gmPos );
            xpos = xpos + advance;
        }
        return gv;
    }
    
    protected void paintComponent(Graphics g) {
        //super.paintComponent( g );
        Graphics2D g2 = (Graphics2D)g;
        if( flg ){
            Insets insets = getInsets();
            int wrap = getWidth() - insets.left - insets.right;
            FontRenderContext frc = g2.getFontRenderContext();
            gvtext = getWrappedGlyphVector( getText(), wrap, getFont(), frc );
            flg = false;
        }
        g2.setPaint( getForeground() );
        g2.drawGlyphVector( gvtext,
                            getInsets().left,
                            getInsets().top + getFont().getSize() );
    }
}