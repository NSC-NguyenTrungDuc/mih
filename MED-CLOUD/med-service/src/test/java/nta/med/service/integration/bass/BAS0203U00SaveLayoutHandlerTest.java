package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class BAS0203U00SaveLayoutHandlerTest extends MessageRequestTest {

    @Test
    public void testBAS0203U00SaveLayoutHandlerTest() throws InterruptedException {

        BassModelProto.BAS0203U00GrdBAS0203Info.Builder bas0203 = BassModelProto.BAS0203U00GrdBAS0203Info.newBuilder();
		bas0203.setBunCode("HK");
		bas0203.setJyDate("2015/10/10");
		bas0203.setFromMonth("10");
		bas0203.setToMonth("11");
		bas0203.setOldToMonth("9");
		bas0203.setRowState("Added");

        List<BassModelProto.BAS0203U00GrdBAS0203Info> dts =
                new ArrayList<BassModelProto.BAS0203U00GrdBAS0203Info>();
        dts.add(bas0203.build());
        
        BassServiceProto.BAS0203U00SaveLayoutRequest request = BassServiceProto.BAS0203U00SaveLayoutRequest
                .newBuilder()
                .setHospCode("K01")
                .setUserId("12")
                .addAllGrdBas0203Item(dts).build();

        sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));


    }
}
