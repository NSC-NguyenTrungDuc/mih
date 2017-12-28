package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.cpl.Cpltemp;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.dao.medi.cpl.CpltempRepository;
import nta.med.data.model.ihis.cpls.CPL0000Q00GetSigeyulDataSelect2ListItemInfo;
import nta.med.data.model.ihis.cpls.MultiResultViewSearchDataSigeyulInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.MultiResultViewGetPreJubsuSigeyulRequest;
import nta.med.service.ihis.proto.CplsServiceProto.MultiResultViewLaySigeyulResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class MultiResultViewGetPreJubsuSigeyulHandler extends ScreenHandler <CplsServiceProto.MultiResultViewGetPreJubsuSigeyulRequest, CplsServiceProto.MultiResultViewLaySigeyulResponse>{                     
	@Resource                                                                                                       
	private CpltempRepository cpltempRepository;
	
	@Resource                                                                                                       
	private Cpl2010Repository cpl2010Repository;
	
	@Resource                                                                                                       
	private Cpl3020Repository cpl3020Repository;
	
	@Override                                                                                                       
	public MultiResultViewLaySigeyulResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			MultiResultViewGetPreJubsuSigeyulRequest request) throws Exception {                                                                   
      	CplsServiceProto.MultiResultViewLaySigeyulResponse.Builder response = CplsServiceProto.MultiResultViewLaySigeyulResponse.newBuilder();        
      	String hospCode = getHospitalCode(vertx, sessionId);
		cpltempRepository.deleteCpltempCPL0000Q00(hospCode, request.getUserId());
		List<CplsModelProto.MultiResultViewGrdSigeyulInfo> grdSigeyul = request.getGrdSigeyulItemList();
		if(!CollectionUtils.isEmpty(grdSigeyul)){
			for(int i = 0;i < grdSigeyul.size(); i++){
				Cpltemp cpltemp = new Cpltemp();
				cpltemp.setIpAddress(request.getUserId());
				cpltemp.setJundalGubun("XX");
				cpltemp.setSeqCode(String.valueOf(i));
				cpltemp.setHangmogCode(grdSigeyul.get(i).getHangmogCode());
				cpltemp.setHospCode(hospCode);
				cpltempRepository.save(cpltemp);
				
				CplsModelProto.MultiResultViewLaySigeyulInfo.Builder laySigeyulInfo = CplsModelProto.MultiResultViewLaySigeyulInfo.newBuilder(); 
				laySigeyulInfo.setGumsaName(grdSigeyul.get(i).getGumsaName());
				List<MultiResultViewSearchDataSigeyulInfo> listSearchData = cpl2010Repository.getMultiResultViewSearchSigeyulInfo2(hospCode
						, grdSigeyul.get(i).getBunho(), request.getUserId(), grdSigeyul.get(i).getGubun(), grdSigeyul.get(i).getBaseDate());
				
				if(!CollectionUtils.isEmpty(listSearchData)){
					int tCnt = 0;
					for(MultiResultViewSearchDataSigeyulInfo searchData : listSearchData){
						tCnt ++;
						if(tCnt > 7){
                            break;
						}
						List<CPL0000Q00GetSigeyulDataSelect2ListItemInfo> ListSearchResult = cpl3020Repository.getCPL0000Q00GetSigeyulDataSelect2(hospCode,
								grdSigeyul.get(i).getBunho(), grdSigeyul.get(i).getHangmogCode(), searchData.getJubsuDate(), searchData.getJubsuTime());
						if(!CollectionUtils.isEmpty(ListSearchResult)){
							CplsModelProto.MultiResultViewDataForLaySigeyulInfo.Builder dataForSigeyulInfo = CplsModelProto.MultiResultViewDataForLaySigeyulInfo.newBuilder();
							dataForSigeyulInfo.setTCnt(String.valueOf(tCnt));
							if(!StringUtils.isEmpty(ListSearchResult.get(0).getFromStandard())){
								dataForSigeyulInfo.setFromStandard(ListSearchResult.get(0).getFromStandard());
							}
							if(!StringUtils.isEmpty(ListSearchResult.get(0).getToStandard())){
								dataForSigeyulInfo.setToStandard(ListSearchResult.get(0).getToStandard());
							}
							if(!StringUtils.isEmpty(ListSearchResult.get(0).getFromStandard())){
								dataForSigeyulInfo.setFromStandard(ListSearchResult.get(0).getFromStandard());
							}
							if(!StringUtils.isEmpty(searchData.getJubsuTime2())){
								dataForSigeyulInfo.setResultDate(searchData.getJubsuTime2());
							}
							if(!StringUtils.isEmpty(ListSearchResult.get(0).getCplResult())){
								dataForSigeyulInfo.setResult(ListSearchResult.get(0).getCplResult());
							}
							if(!StringUtils.isEmpty(ListSearchResult.get(0).getStandardYn())){
								dataForSigeyulInfo.setStandardYn(ListSearchResult.get(0).getStandardYn());
							}
							
							laySigeyulInfo.addDataInfo(dataForSigeyulInfo);
						}
					}
				}
				response.addLaySigeyulInfo(laySigeyulInfo);
			}
		}
		return response.build();
	}
}
