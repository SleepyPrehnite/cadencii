﻿package org.kbinani.cadencii;

//SECTION-BEGIN-IMPORT
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import javax.swing.JButton;
import javax.swing.JPanel;
import org.kbinani.windows.forms.BButton;
import org.kbinani.windows.forms.BForm;
import org.kbinani.windows.forms.BLabel;
import org.kbinani.windows.forms.BTextArea;

//SECTION-END-IMPORT
public class FormImportLyric extends BForm {
    //SECTION-BEGIN-FIELD

    private static final long serialVersionUID = 1L;
    private JPanel jContentPane = null;
    private BLabel lblNotes = null;
    private BTextArea txtLyrics = null;
    private JPanel jPanel = null;
    private BButton btnOK = null;
    private BButton btnCancel = null;
    //SECTION-END-FIELD
    /**
     * This is the default constructor
     */
    public FormImportLyric() {
    	super();
    	initialize();
    }
    //SECTION-BEGIN-METHOD

    /**
     * This method initializes this
     * 
     * @return void
     */
    private void initialize() {
    	this.setSize(456, 380);
    	this.setContentPane(getJContentPane());
    	this.setTitle("JFrame");
    }
    
    /**
     * This method initializes jContentPane
     * 
     * @return javax.swing.JPanel
     */
    private JPanel getJContentPane() {
    	if (jContentPane == null) {
    		GridBagConstraints gridBagConstraints4 = new GridBagConstraints();
    		gridBagConstraints4.gridx = 0;
    		gridBagConstraints4.anchor = GridBagConstraints.EAST;
    		gridBagConstraints4.insets = new Insets(0, 0, 16, 0);
    		gridBagConstraints4.gridy = 2;
    		GridBagConstraints gridBagConstraints1 = new GridBagConstraints();
    		gridBagConstraints1.fill = GridBagConstraints.BOTH;
    		gridBagConstraints1.gridy = 1;
    		gridBagConstraints1.weightx = 1.0;
    		gridBagConstraints1.weighty = 1.0;
    		gridBagConstraints1.insets = new Insets(0, 16, 16, 16);
    		gridBagConstraints1.gridx = 0;
    		GridBagConstraints gridBagConstraints = new GridBagConstraints();
    		gridBagConstraints.gridx = 0;
    		gridBagConstraints.anchor = GridBagConstraints.WEST;
    		gridBagConstraints.insets = new Insets(16, 16, 8, 0);
    		gridBagConstraints.gridy = 0;
    		lblNotes = new BLabel();
    		lblNotes.setText("Max : *[notes]");
    		jContentPane = new JPanel();
    		jContentPane.setLayout(new GridBagLayout());
    		jContentPane.add(lblNotes, gridBagConstraints);
    		jContentPane.add(getTxtLyrics(), gridBagConstraints1);
    		jContentPane.add(getJPanel(), gridBagConstraints4);
    	}
    	return jContentPane;
    }
    
    /**
     * This method initializes txtLyrics	
     * 	
     * @return javax.swing.BTextArea	
     */
    private BTextArea getTxtLyrics() {
    	if (txtLyrics == null) {
    		txtLyrics = new BTextArea();
    	}
    	return txtLyrics;
    }
    
    /**
     * This method initializes jPanel	
     * 	
     * @return javax.swing.JPanel	
     */
    private JPanel getJPanel() {
    	if (jPanel == null) {
    		GridBagConstraints gridBagConstraints3 = new GridBagConstraints();
    		gridBagConstraints3.gridx = 1;
    		gridBagConstraints3.insets = new Insets(0, 0, 0, 16);
    		gridBagConstraints3.gridy = 0;
    		GridBagConstraints gridBagConstraints2 = new GridBagConstraints();
    		gridBagConstraints2.gridx = 0;
    		gridBagConstraints2.insets = new Insets(0, 0, 0, 16);
    		gridBagConstraints2.gridy = 0;
    		jPanel = new JPanel();
    		jPanel.setLayout(new GridBagLayout());
    		jPanel.add(getBtnOK(), gridBagConstraints2);
    		jPanel.add(getBtnCancel(), gridBagConstraints3);
    	}
    	return jPanel;
    }
    
    /**
     * This method initializes btnOK	
     * 	
     * @return javax.swing.BButton	
     */
    private BButton getBtnOK() {
    	if (btnOK == null) {
    		btnOK = new BButton();
    		btnOK.setText("OK");
    	}
    	return btnOK;
    }
    
    /**
     * This method initializes btnCancel	
     * 	
     * @return javax.swing.BButton	
     */
    private BButton getBtnCancel() {
        if (btnCancel == null) {
            btnCancel = new BButton();
            btnCancel.setText("Cancel");
        }
        return btnCancel;
    }
    
    //SECTION-END-METHOD
}
