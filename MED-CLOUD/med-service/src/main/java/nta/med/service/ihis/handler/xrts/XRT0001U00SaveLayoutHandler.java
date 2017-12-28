package nta.med.service.ihis.handler.xrts;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.xrt.Xrt0001;
import nta.med.core.domain.xrt.Xrt0002;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.xrt.Xrt0001Repository;
import nta.med.data.dao.medi.xrt.Xrt0002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0001U00SaveLayoutInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class XRT0001U00SaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0001U00SaveLayoutHandler.class);
    @Resource
    private Xrt0001Repository xrt0001Repository;
    @Resource
    private Xrt0002Repository xrt0002Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0001U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        try{
            String hospitalCode = getHospitalCode(vertx, sessionId);
            for (XRT0001U00SaveLayoutInfo info : request.getSaveLayoutItemList()) {
                if (info.getCallerId().equalsIgnoreCase("1")) {
                    if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                        result = insertXRT0001(info, request.getUserId(), hospitalCode);
                    } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                        result = updateXrt0001(info, request.getUserId(), hospitalCode);
                    } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                        result = xrt0001Repository.deleteXRT0001U00ExecuteCase1(hospitalCode, info.getXrayCode());
                    }
                } else if (info.getCallerId().equalsIgnoreCase("2")) {
                    if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                        result = insertXrt0002(info, request.getUserId(), hospitalCode);
                    } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                        result = updateXrt0002(info, request.getUserId(), hospitalCode);
                    } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                        result = xrt0002Repository.deleteXRT0001U00ExecuteCase2(hospitalCode, info.getXrayCode(), info.getXrayCodeIdx());
                    }
                }
            }
        }
        catch (Exception e)
        {
            response.setResult(false);
            throw new ExecutionException(response.build());
        }

        response.setResult(result != null && result > 0);
        return response.build();
    }

    private Integer insertXRT0001(XRT0001U00SaveLayoutInfo request, String userId, String hospitalCode) {
        try {
            Xrt0001 xrt0001 = new Xrt0001();
            xrt0001.setSysDate(new Date());
            xrt0001.setSysId(userId);
            xrt0001.setUpdDate(new Date());
            xrt0001.setUpdId(userId);
            xrt0001.setHospCode(hospitalCode);
        	xrt0001.setXrayCode(request.getXrayCode());
        	xrt0001.setXrayName(request.getXrayName());
            if(!StringUtils.isEmpty(request.getXrayGubun())){
            	xrt0001.setXrayGubun(request.getXrayGubun());
            }
            if(!StringUtils.isEmpty(request.getXrayRoom())){
            	xrt0001.setXrayRoom(request.getXrayRoom());
            }
            if(!StringUtils.isEmpty(request.getXrayBuwi())){
            	xrt0001.setXrayBuwi(request.getXrayBuwi());
            }
            if(!StringUtils.isEmpty(request.getXrayBuwiKaikei())){
            	xrt0001.setXrayBuwiKaikei(request.getXrayBuwiKaikei());
            }
            if(!StringUtils.isEmpty(request.getXrayBuwiTong())){
            	xrt0001.setXrayBuwiTong(request.getXrayBuwiTong());
            }
        	xrt0001.setXrayCnt(CommonUtils.parseDouble(request.getXrayCnt()));
            xrt0001.setNamePrintYn(request.getNamePrintYn());
            xrt0001.setSugaCode(request.getSugaCode());
            xrt0001.setSpecialYn(request.getSpecialYn());
            xrt0001.setXrayName2(request.getXrayName2());
            xrt0001.setXrayRealCnt(CommonUtils.parseDouble(request.getXrayRealCnt()));
            xrt0001.setSlipCode(request.getSlipCode());
            if(!StringUtils.isEmpty(request.getReserType())){
            	xrt0001.setReserType(request.getReserType());
            }
            xrt0001.setJaeryoYn(request.getJaeryoYn());
            xrt0001.setSort(request.getSort());
            if(!StringUtils.isEmpty(request.getXrayWay())){
            	xrt0001.setXrayWay(request.getXrayWay());
            }
            xrt0001.setTongGubun(request.getTongGubun());
            xrt0001.setRequestYn(request.getRequestYn());
            if(!StringUtils.isEmpty(request.getModality())){
            	xrt0001.setModality(request.getModality());
            }
            xrt0001.setFrequentUseYn(request.getFrequentUseYn());
            xrt0001.setTubeVol(request.getTubeVol());
            xrt0001.setTubeCur(request.getTubeCur());
            xrt0001.setXrayTime(request.getXrayTime());
            xrt0001.setTubeCurTime(request.getTubeCurTime());
            xrt0001.setIrradiationTime(request.getIrradiationTime());
            xrt0001.setXrayDistance(request.getXrayDistance());
            xrt0001Repository.save(xrt0001);
            return 1;
        } catch (Exception e) {
            LOGGER.error("Error on insertXrt0101 " + e.getMessage(), e);
            throw new ExecutionException(e.getMessage(), e);
        }
    }

    private Integer updateXrt0001(XRT0001U00SaveLayoutInfo request, String userId, String hospitalCode) {
        try {
            List<Xrt0001> listXrt0001 = xrt0001Repository.getObjectXrt0001ExecuteCase1(hospitalCode, request.getXrayCode());
            if (!CollectionUtils.isEmpty(listXrt0001)) {
                for (Xrt0001 xrt0001 : listXrt0001) {
                    xrt0001.setUpdId(userId);
                    xrt0001.setUpdDate(new Date());
                    xrt0001.setXrayName(request.getXrayName());
                    if(!StringUtils.isEmpty(request.getXrayGubun())){
                    	xrt0001.setXrayGubun(request.getXrayGubun());
                    }
                    if(!StringUtils.isEmpty(request.getXrayRoom())){
                    	xrt0001.setXrayRoom(request.getXrayRoom());
                    }
                    if(!StringUtils.isEmpty(request.getXrayBuwi())){
                    	xrt0001.setXrayBuwi(request.getXrayBuwi());
                    }
                    if(!StringUtils.isEmpty(request.getXrayBuwiKaikei())){
                    	xrt0001.setXrayBuwiKaikei(request.getXrayBuwiKaikei());
                    }
                    if(!StringUtils.isEmpty(request.getXrayBuwiTong())){
                    	xrt0001.setXrayBuwiTong(request.getXrayBuwiTong());
                    }
                    xrt0001.setXrayCnt(CommonUtils.parseDouble(request.getXrayCnt()));
                    xrt0001.setNamePrintYn(request.getNamePrintYn());
                    xrt0001.setSugaCode(request.getSugaCode());
                    xrt0001.setSpecialYn(request.getSpecialYn());
                    xrt0001.setXrayName2(request.getXrayName2());
                    xrt0001.setXrayRealCnt(CommonUtils.parseDouble(request.getXrayRealCnt()));
                    xrt0001.setSlipCode(request.getSlipCode());
                    if(!StringUtils.isEmpty(request.getReserType())){
                    	xrt0001.setReserType(request.getReserType());	
                    }
                    xrt0001.setJaeryoYn(request.getJaeryoYn());
                    xrt0001.setSort(request.getSort());
                    if(!StringUtils.isEmpty(request.getXrayWay())){
                    	xrt0001.setXrayWay(request.getXrayWay());
                    }
                    xrt0001.setTongGubun(request.getTongGubun());
                    xrt0001.setRequestYn(request.getRequestYn());
                    if(!StringUtils.isEmpty(request.getModality())){
                    	xrt0001.setModality(request.getModality());
                    }
                    xrt0001.setFrequentUseYn(request.getFrequentUseYn());
                    xrt0001.setTubeVol(request.getTubeVol());
                    xrt0001.setTubeCur(request.getTubeCur());
                    xrt0001.setXrayTime(request.getXrayTime());
                    xrt0001.setTubeCurTime(request.getTubeCurTime());
                    xrt0001.setIrradiationTime(request.getIrradiationTime());
                    xrt0001.setXrayDistance(request.getXrayDistance());
                }
            }
            xrt0001Repository.save(listXrt0001);
            return 1;
        } catch (Exception e) {
            LOGGER.error("Error on insertXrt0101 " + e.getMessage(), e);
//			return 0;
            throw new ExecutionException(e.getMessage(), e);
        }
    }

    private Integer insertXrt0002(XRT0001U00SaveLayoutInfo request, String userId, String hospitalCode) {
        try {
            Xrt0002 xrt0002 = new Xrt0002();
            xrt0002.setSysDate(new Date());
            xrt0002.setUpdId(userId);
            xrt0002.setUpdDate(new Date());
            xrt0002.setHospCode(hospitalCode);
            xrt0002.setXrayCode(request.getXrayCode());
            xrt0002.setXrayGubun(request.getXrayGubun());
            xrt0002.setXrayCodeIdx(request.getXrayCodeIdx());
            xrt0002.setXrayCodeIdxNm(request.getXrayCodeIdxNm());
            xrt0002.setTubeVol(request.getTubeVol());
            xrt0002.setTubeCur(request.getTubeCur());
            xrt0002.setXrayTime(request.getXrayTime());
            xrt0002.setTubeCurTime(request.getTubeCurTime());
            xrt0002.setIrradiationTime(request.getIrradiationTime());
            xrt0002.setXrayDistance(request.getXrayDistance());
            xrt0002Repository.save(xrt0002);
            return 1;
        } catch (Exception e) {
            LOGGER.error("Error on insertXrt0101 " + e.getMessage(), e);
            throw new ExecutionException(e.getMessage(), e );
        }
    }

    private Integer updateXrt0002(XRT0001U00SaveLayoutInfo request, String userId, String hospitalCode) {
        try {
            List<Xrt0002> listXrt0002 = xrt0002Repository.getObjectXrt0002ExecuteCase2(hospitalCode, request.getXrayCode(), request.getXrayCodeIdx());
            if (!CollectionUtils.isEmpty(listXrt0002)) {
                for (Xrt0002 xrt0002 : listXrt0002) {
                    xrt0002.setUpdId(userId);
                    xrt0002.setUpdDate(new Date());
                    xrt0002.setHospCode(hospitalCode);
                    xrt0002.setXrayCode(request.getXrayCode());
                    xrt0002.setXrayGubun(request.getXrayGubun());
                    xrt0002.setXrayCodeIdx(request.getXrayCodeIdx());
                    xrt0002.setXrayCodeIdxNm(request.getXrayCodeIdxNm());
                    xrt0002.setTubeVol(request.getTubeVol());
                    xrt0002.setTubeCur(request.getTubeCur());
                    xrt0002.setXrayTime(request.getXrayTime());
                    xrt0002.setTubeCurTime(request.getTubeCurTime());
                    xrt0002.setIrradiationTime(request.getIrradiationTime());
                    xrt0002.setXrayDistance(request.getXrayDistance());
                }
            }
            xrt0002Repository.save(listXrt0002);
            return 1;
        } catch (Exception e) {
            LOGGER.error("Error on insertXrt0101 " + e.getMessage(), e);
//			return 0;
            throw new ExecutionException(e.getMessage(), e);
        }
    }
}