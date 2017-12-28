package nta.med.core.utils;

import nta.med.core.glossary.Language;
import org.springframework.beans.BeansException;
import org.springframework.beans.FatalBeanException;
import org.springframework.util.Assert;

import java.beans.PropertyDescriptor;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

public class BeanUtils {

	public static void copyProperties(Object source, Object target, String language) throws BeansException {
		copyProperties(source, target, null, Language.newInstance(language), (String[]) null);
	}

	private static void copyProperties(Object source, Object target, Class<?> editable, Language language, String... ignoreProperties)
			throws BeansException {

		Assert.notNull(source, "Source must not be null");
		Assert.notNull(target, "Target must not be null");

		Class<?> actualEditable = target.getClass();
		if (editable != null) {
			if (!editable.isInstance(target)) {
				throw new IllegalArgumentException("Target class [" + target.getClass().getName() +
						"] not assignable to Editable class [" + editable.getName() + "]");
			}
			actualEditable = editable;
		}
		PropertyDescriptor[] targetPds = org.springframework.beans.BeanUtils.getPropertyDescriptors(actualEditable);
		List<String> ignoreList = (ignoreProperties != null ? Arrays.asList(ignoreProperties) : null);

		for (PropertyDescriptor targetPd : targetPds) {
			Method writeMethod = targetPd.getWriteMethod();
			if (writeMethod != null && (ignoreList == null || (!ignoreList.contains(targetPd.getName())))) {
				PropertyDescriptor sourcePd = org.springframework.beans.BeanUtils.getPropertyDescriptor(source.getClass(), targetPd.getName());
				if (sourcePd != null) {
					Method readMethod = sourcePd.getReadMethod();
					if (readMethod != null) {
						try {
							if (!Modifier.isPublic(readMethod.getDeclaringClass().getModifiers())) {
								readMethod.setAccessible(true);
							}
							Object value = readMethod.invoke(source);
							if (value != null) {
								if (!Modifier.isPublic(writeMethod.getDeclaringClass().getModifiers())) {
									writeMethod.setAccessible(true);
								}
								if(!sourcePd.getPropertyType().equals(targetPd.getPropertyType())) {
									if(Date.class.equals(sourcePd.getPropertyType()) && String.class.equals(targetPd.getPropertyType())) {
										writeMethod.invoke(target,DateUtil.toString((Date)value, DateUtil.PATTERN_YYMMDD));
									}
									if(Timestamp.class.equals(sourcePd.getPropertyType()) && String.class.equals(targetPd.getPropertyType())) {
										writeMethod.invoke(target,DateUtil.toString((Date)value, DateUtil.PATTERN_YYMMDD));
									}
									if(Double.class.equals(sourcePd.getPropertyType()) && String.class.equals(targetPd.getPropertyType())) {
										writeMethod.invoke(target, language.fromDouble((Double) value));
									}
									if(Integer.class.equals(sourcePd.getPropertyType()) && String.class.equals(targetPd.getPropertyType())) {
										writeMethod.invoke(target, (Integer)value + "");
									}
									if(BigDecimal.class.equals(sourcePd.getPropertyType()) && String.class.equals(targetPd.getPropertyType())) {
										writeMethod.invoke(target, (BigDecimal)value + "");
									}

									if( String.class.equals(sourcePd.getPropertyType()) && Date.class.equals(targetPd.getPropertyType())) {
										if(value.toString().contains("/")){
											writeMethod.invoke(target, DateUtil.toDate((String)value, DateUtil.PATTERN_YYMMDD));
										}
									}
									if(String.class.equals(sourcePd.getPropertyType()) && Double.class.equals(targetPd.getPropertyType())) {
										writeMethod.invoke(target, CommonUtils.parseDouble((String)value));
									}
								}  else {
									writeMethod.invoke(target, value);
								}
							}
						}
						catch (Throwable ex) {
							throw new FatalBeanException(
									"Could not copy property '" + targetPd.getName() + "' from source to target", ex);
						}
					}
				}
			}
		}
	}
}
