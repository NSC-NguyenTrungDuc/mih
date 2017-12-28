package nta.med.core.caching;

import nta.med.core.infrastructure.context.DbContext;
import org.springframework.cache.interceptor.KeyGenerator;
import org.springframework.util.ObjectUtils;

import java.lang.reflect.Method;

/**
 * @author dainguyen.
 */
public class StringKeyGenerator implements KeyGenerator {

    @Override
    public Object generate(Object target, Method method, Object... params) {
        return DbContext.getShardingKey() + target.getClass().getSimpleName() + ":" + method.getName() + "[" + generate(params) + "]";
    }

    private Object generate(Object[] params) {
        if (params.length == 0) {
            return "";
        }
        if (params.length == 1) {
            Object param = params[0];
            if (param == null) {
                return "null";
            }
            if (!param.getClass().isArray()) {
                return ObjectUtils.nullSafeHashCode(param);
            }
        }
        return arrayToDelimitedString(params, "_");
    }

    public static String arrayToDelimitedString(Object[] arr, String delimiter) {
        if(ObjectUtils.isEmpty(arr)) {
            return "";
        } else if(arr.length == 1) {
            return String.valueOf(ObjectUtils.nullSafeHashCode(arr[0]));
        } else {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < arr.length; ++i) {
                if(i > 0) {
                    sb.append(delimiter);
                }

                sb.append(ObjectUtils.nullSafeHashCode(arr[i]));
            }

            return sb.toString();
        }
    }

}
