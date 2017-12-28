package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.data.model.ihis.bass.BAS0110BAS0110Q00GrdInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110Q00GrdBAS0110Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110Q00GrdBAS0110Response;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110Q00GrdBAS0110Handler extends ScreenHandler<BassServiceProto.BAS0110Q00GrdBAS0110Request, BassServiceProto.BAS0110Q00GrdBAS0110Response>{                     
	private static final Log LOGGER = LogFactory.getLog(BAS0110Q00GrdBAS0110Handler.class);                                    
	@Resource                                                                                                       
	private Bas0110Repository bas0110Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0110Q00GrdBAS0110Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0110Q00GrdBAS0110Request request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0110Q00GrdBAS0110Response.Builder response = BassServiceProto.BAS0110Q00GrdBAS0110Response.newBuilder();                      
		List<BAS0110BAS0110Q00GrdInfo> listGrd = bas0110Repository.getBAS0110BAS0110Q00GrdInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
			request.getJohapGubun(), request.getSearchGubun(), request.getSearchWord());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(BAS0110BAS0110Q00GrdInfo item : listGrd){
				BassModelProto.BAS0110Q00GrdBAS0110ItemInfo.Builder info = BassModelProto.BAS0110Q00GrdBAS0110ItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getJohap())) {
					info.setJohap(item.getJohap());
				}
				if (item.getStartDate() != null) {
					info.setStartDate(DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getJohapName())) {
					info.setJohapName(item.getJohapName());
				}
				if (!StringUtils.isEmpty(item.getJohapGubun())) {
					info.setJohapGubun(item.getJohapGubun());
				}
				if (!StringUtils.isEmpty(item.getZipCode1())) {
					info.setZipCode1(item.getZipCode1());
				}
				if (!StringUtils.isEmpty(item.getZipCode2())) {
					info.setZipCode2(item.getZipCode2());
				}
				if (!StringUtils.isEmpty(item.getAddress())) {
					info.setAddress(item.getAddress());
				}
				if (!StringUtils.isEmpty(item.getTel())) {
					info.setTel(item.getTel());
				}
				if (!StringUtils.isEmpty(item.getLawNo())) {
					info.setLawNo(item.getLawNo());
				}
				if (!StringUtils.isEmpty(item.getDodobuhyeunNo())) {
					info.setDodobuhyeunNo(item.getDodobuhyeunNo());
				}
				if (!StringUtils.isEmpty(item.getBoheomjaNo())) {
					info.setBoheomjaNo(item.getBoheomjaNo());
				}
				if (!StringUtils.isEmpty(item.getCd())) {
					info.setCd(item.getCd());
				}
				if (!StringUtils.isEmpty(item.getGiho())) {
					info.setGiho(item.getGiho());
				}
				if (!StringUtils.isEmpty(item.getRemark())) {
					info.setRemark(item.getRemark());
				}
				if (!StringUtils.isEmpty(item.getCheckDigitYn())) {
					info.setCheckDigitYn(item.getCheckDigitYn());
				}
				if (!StringUtils.isEmpty(item.getLoadCodeName())) {
					info.setJohapGubunName(item.getLoadCodeName());
				}
				response.addGrdBas0110ItemInfo(info);
			}
		}
		return response.build();
	}
}