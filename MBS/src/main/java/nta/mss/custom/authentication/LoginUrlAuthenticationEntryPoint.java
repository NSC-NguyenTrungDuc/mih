package nta.mss.custom.authentication;

import nta.kcck.service.impl.KcckDepartmentService;
import nta.mss.info.BookingInfo;
import nta.mss.info.HospitalDto;
import nta.mss.info.ScheduleInfo;
import nta.mss.misc.common.DomainNameUtils;
import nta.mss.misc.common.EncryptionUtils;
import nta.mss.misc.common.MssConfiguration;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.service.IHospitalService;
import org.apache.logging.log4j.util.Strings;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.AuthenticationException;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * @author DEV-TiepNM
 */
public class LoginUrlAuthenticationEntryPoint extends org.springframework.security.web.authentication.LoginUrlAuthenticationEntryPoint {
    @Autowired
    IHospitalService hospitalService;
    @Autowired
    KcckDepartmentService kcckDepartmentService;

    @Override
    public void commence(HttpServletRequest request, HttpServletResponse response, AuthenticationException authException) throws IOException, ServletException {
        String tokenHospCode = request.getParameter("tokenHospCode");
        if(Strings.isEmpty(tokenHospCode))
        {
            Cookie cookie[]=request.getCookies();
            Cookie cook;

            if (cookie != null) {
                for (int i = 0; i < cookie.length; i++) {
                    cook = cookie[i];
                    if(cook.getName().equalsIgnoreCase("tokenHospCode"))
                    {
                        tokenHospCode = cook.getValue();
                        break;
                    }
                }
            }
        }
        if(!Strings.isEmpty(tokenHospCode))
        {
            String lang = request.getParameter("lang");
            if (!Strings.isEmpty(tokenHospCode) &&
                    MssContextHolder.getTokenHospCode() == null &&
                    MssContextHolder.getHospCode() == null) {
                try {
                    String hospCode = EncryptionUtils.decrypt(tokenHospCode, MssConfiguration.getInstance().getSecretKey(),
                            EncryptionUtils.ENCRYPT_ALGORITHM_AES, EncryptionUtils.ENCRYPT_TRANSFORMATION_AES_CBC_PADDING);
                    MssContextHolder.setHospCode(hospCode);
                    MssContextHolder.setTokenHospCode(tokenHospCode);
                    if (!Strings.isEmpty(lang)) {
                        MssContextHolder.setUserLanguage(lang);
                    }
                    HospitalDto hospital = hospitalService.getHospitalModelByHospitalCode(hospCode);
                    if (hospital != null) {
                        MssContextHolder.setHospitalId(hospital.getHospitalId());
                        MssContextHolder.setHospitalId(hospital.getHospitalId());
                        MssContextHolder.setHospitalName(hospital.getHospitalName());
                        MssContextHolder.setHospitalIconPath(hospital.getHospitalIconPath());
                        MssContextHolder.setTokenHospCode(tokenHospCode);
                        MssContextHolder.setHospCode(hospCode);
                        MssContextHolder.setUserLanguage(hospital.getLocale());
                        MssContextHolder.setHospitalLocale(hospital.getLocale());
                        MssContextHolder.setHospitalEmail(hospital.getEmail());
                        MssContextHolder.setTimeZone(hospital.getTimeZone());
                        MssContextHolder.setHospitalParentId(hospital.getHospitalParentId());
                        MssContextHolder.setIsUseVaccine(hospital.getIsUseVaccine() == null ? 0 : hospital.getIsUseVaccine());
                        MssContextHolder.setIsUseMt(hospital.getIsUseMt());
                        MssContextHolder.setHospital(hospital);
                        MssContextHolder.setBookingInfo(new BookingInfo());

                        MssContextHolder.setScheduleInfo(new ScheduleInfo());

                        MssContextHolder.setDomainName(DomainNameUtils.getDomainName(hospital.getLocale()));
                        MssContextHolder.setKcckDepartmentList(kcckDepartmentService.getListDepartment(hospCode, hospital.getLocale()));

                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }

        super.commence(request, response, authException);
    }
}
