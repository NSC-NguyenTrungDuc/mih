package nta.mss.converter;

import java.beans.IntrospectionException;
import java.beans.PropertyDescriptor;
import java.beans.PropertyEditor;
import java.beans.PropertyEditorManager;
import java.lang.reflect.InvocationTargetException;
import java.math.BigDecimal;
import java.util.AbstractMap;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import nta.mss.misc.enums.CsvErrorCode;

import org.apache.commons.lang.StringUtils;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.apache.xbean.propertyeditor.BigDecimalEditor;
import org.apache.xbean.propertyeditor.IntegerEditor;
import org.apache.xbean.propertyeditor.PropertyEditorException;

import au.com.bytecode.opencsv.CSVReader;
import au.com.bytecode.opencsv.bean.CsvToBean;
import au.com.bytecode.opencsv.bean.MappingStrategy;

/**
 * The Class ApiCsvToBean.
 *
 * @param <T> the generic type
 */
public class ApiCsvToBean<T> extends CsvToBean<T> {
	private static final Logger LOG = LogManager.getLogger(ApiCsvToBean.class);
    
    /** The is initialized. */
    private static boolean isInitialized = false;

    /**
     * Ensure registered editor.
     */
    public static void ensureRegisteredEditor(){
        if(!isInitialized){
            PropertyEditorManager.registerEditor(Integer.class, IntegerEditor.class);
            PropertyEditorManager.registerEditor(BigDecimal.class, BigDecimalEditor.class);
            isInitialized = true;
        }
    }

    /**
     * Parses the.
     *
     * @param mapper the mapper
     * @param csv the csv
     * @param noMappingField the no mapping field
     * @param noIgnoredRows the no ignored rows
     * @return the list
     */
    public List<Map.Entry<T, CsvErrorCode>> parse(MappingStrategy<T> mapper, CSVReader csv, int noMappingField, int noIgnoredRows, boolean replaceSpecialChar) throws RuntimeException {
        try {
//            mapper.captureHeader(csv);
            String[] line;
            List<Map.Entry<T, CsvErrorCode>> list = new ArrayList<Map.Entry<T, CsvErrorCode>>();
            int i = 1;
            while (null != (line = csv.readNext())) {
                if (i > noIgnoredRows) {
                    if (noMappingField != line.length) {
                    	LOG.info("NOT ENOUGH FIELD");
                        list.add(new AbstractMap.SimpleEntry<T, CsvErrorCode>(null, CsvErrorCode.NOT_ENOUGH_DATA));
                    } else {
                        T obj = null;
                        CsvErrorCode errorCode = null;
                        try {
                        	if (replaceSpecialChar) {
                        		line[0] = line[0].replaceAll("[^\\p{ASCII}]", "");
                        	}
                            obj = processLine(mapper, line);
                        } catch (NumberFormatException e){
                            LOG.error(e.getMessage(),e);
                            errorCode = CsvErrorCode.WRONG_FORMAT;
                        } catch (PropertyEditorException e){
                            LOG.error(e.getMessage(),e);
                            errorCode = CsvErrorCode.WRONG_FORMAT;
                        } catch (Exception e){
                            LOG.error(e.getMessage(),e);
                            errorCode = CsvErrorCode.INVALID;
                        }
                        list.add(new AbstractMap.SimpleEntry<T, CsvErrorCode>(obj, errorCode));
                    }
                }
                i++;
            }
            return list;
        } catch (Exception e) {
        	LOG.error(e.getMessage(),e);
            throw new RuntimeException("Error parsing CSV!", e);
        }
    }
    
    /* (non-Javadoc)
     * @see au.com.bytecode.opencsv.bean.CsvToBean#processLine(au.com.bytecode.opencsv.bean.MappingStrategy, java.lang.String[])
     */
    @Override
    protected T processLine(MappingStrategy<T> mapper, String[] line) throws IllegalAccessException, InvocationTargetException, InstantiationException, IntrospectionException {
        T bean = mapper.createBean();
        for (int col = 0; col < line.length; col++) {
            PropertyDescriptor prop = mapper.findDescriptor(col);
            if (null != prop) {
                String value = line[col].trim();
                Object obj = convertValue(value, prop);
                prop.getWriteMethod().invoke(bean, obj);
            }
        }
        return bean;
    }

    /* (non-Javadoc)
     * @see au.com.bytecode.opencsv.bean.CsvToBean#convertValue(java.lang.String, java.beans.PropertyDescriptor)
     */
    @Override
    protected Object convertValue(String value, PropertyDescriptor prop) throws InstantiationException, IllegalAccessException {
        PropertyEditor editor = getPropertyEditor(prop);
        Object obj = value.trim();
        if (null != editor) {
            if(editor.getClass().equals(IntegerEditor.class) || editor.getClass().equals(BigDecimalEditor.class)){
            	if(StringUtils.isBlank(value)){
            		return null;
            	}
            }
            editor.setAsText(value);
            obj = editor.getValue();
        }
        return obj;
    }

}
